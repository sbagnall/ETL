namespace SteveBagnall.Etl.Specification
{
	using System;

	public class EtlProcess<T> : IEtlProcess where T : IEquatable<T>
	{
		public IManifest<T> Manifest { get; set; }
		public IExtracter<T> Extracter { get; set; }
		public ITransformer<T> Transformer { get; set; }
		public ILoader<T> Loader { get; set; }

		public EtlProcess()
		{ }

		public EtlProcess(IManifest<T> manifest, IExtracter<T> extracter, ITransformer<T> transformer, ILoader<T> loader)
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
				if (extract != null)
				{
					var current = extract.CurrentPosition;

					// avoid loops
					if ((!(current.Equals(lastCurrentPosition))) && (extract.IsSuccess))
					{
						Loader.EnsureNext(current);

						foreach (var transformation in Transformer.Transform(extract))
						{
							if (transformation != null)
							{
								Loader.Load(transformation);

								transformation.CleanUp();
							}
						}

						extract.CleanUp();

						Manifest.Update(current);
						lastCurrentPosition = current;
					}
				}
			}
		}
	}
}
