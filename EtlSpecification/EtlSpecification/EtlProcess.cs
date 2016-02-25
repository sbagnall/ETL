namespace SteveBagnall.Etl.Specification
{
	using System;
	using SteveBagnall.Etl.Specification.Abstract;

	public class EtlProcess<T> : IEtlProcess where T : IEquatable<T>
	{
		public IManifest<T> Manifest { get; set; }
		public IExtracter<T> Extracter { get; set; }
		public ITransformer<T> Transformer { get; set; }
		public ILoader Loader { get; set; }

		public EtlProcess()
		{ }

		public EtlProcess(IManifest<T> manifest, IExtracter<T> extracter, ITransformer<T> transformer, ILoader loader)
		{
			Manifest = manifest;
			Extracter = extracter;
			Transformer = transformer;
			Loader = loader;
		}

		public void Initialize()
		{
			Manifest.Clear();

			Loader.Clear();
		}

		public void Execute()
		{
			T lastCurrentPosition = default(T);

			var last = Manifest.GetLast();

			foreach (var extract in Extracter.Extract(last))
			{
				// avoid loops
				if ((!(extract.CurrentPosition.Equals(lastCurrentPosition)))
					&& (extract.IsSuccess))
				{
					if (extract != null)
					{
						foreach (var transformation in Transformer.Transform(extract))
						{
							if (transformation != null)
							{
								Loader.Load(transformation);

								transformation.CleanUp();
							}
						}

						extract.CleanUp();
					}

					var current = extract.CurrentPosition;
				
					Manifest.Update(current);
					lastCurrentPosition = current;
				}
			}
		}
	}
}
