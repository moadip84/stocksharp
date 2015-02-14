namespace StockSharp.Algo.Storages
{
	using System;
	using System.IO;
	using System.Linq;

	using Ecng.Collections;
	using Ecng.Common;

	/// <summary>
	/// ��������� ����������� ������.
	/// </summary>
	/// <typeparam name="TData">��� ������-������.</typeparam>
	public interface IDataStorageReader<TData> : IDisposable
	{
		/// <summary>
		/// �����.
		/// </summary>
		Stream Stream { get; }

		/// <summary>
		/// ����-���������� � ������ �� ���� ����.
		/// </summary>
		IMarketDataMetaInfo MetaInfo { get; }

		/// <summary>
		/// ��������� ������.
		/// </summary>
		/// <returns>������. ���� ������ �� ����������, �� ����� ���������� ������ ���������.</returns>
		IEnumerableEx<TData> Load();
	}

	/// <summary>
	/// ����������� ������.
	/// </summary>
	/// <typeparam name="TData">��� ������-������.</typeparam>
	class DataStorageReader<TData> : Disposable, IDataStorageReader<TData>
	{
		private readonly Stream _stream;
		private readonly IMarketDataMetaInfo _metaInfo;
		private readonly IMarketDataSerializer<TData> _serializer;

		/// <summary>
		/// �����.
		/// </summary>
		public Stream Stream { get { return _stream; } }

		/// <summary>
		/// ����-���������� � ������ �� ���� ����.
		/// </summary>
		public IMarketDataMetaInfo MetaInfo { get { return _metaInfo; } }

		/// <summary>
		/// ������� <see cref="DataStorageReader{TData}"/>.
		/// </summary>
		/// <param name="stream">�����.</param>
		/// <param name="metaInfo">����-���������� � ������ �� ���� ����.</param>
		/// <param name="serializer">������������.</param>
		public DataStorageReader(Stream stream, IMarketDataMetaInfo metaInfo, IMarketDataSerializer<TData> serializer)
		{
			if (stream == null)
				throw new ArgumentNullException("stream");

			if (serializer == null)
				throw new ArgumentNullException("serializer");

			_stream = stream;
			_metaInfo = metaInfo;
			_serializer = serializer;
		}

		/// <summary>
		/// ��������� ������.
		/// </summary>
		/// <returns>������. ���� ������ �� ����������, �� ����� ���������� ������ ���������.</returns>
		public IEnumerableEx<TData> Load()
		{
			_stream.Position = 0;

			return _metaInfo == null 
				? Enumerable.Empty<TData>().ToEx() 
				: _serializer.Deserialize(_stream, _metaInfo);
		}

		/// <summary>
		/// �������� �������.
		/// </summary>
		protected override void DisposeManaged()
		{
			_stream.Dispose();
			base.DisposeManaged();
		}
	}

	class ConvertableDataStorageReader<TData, TSource> : Disposable, IDataStorageReader<TData>
	{
		private readonly IDataStorageReader<TSource> _reader;
		private readonly Func<IEnumerableEx<TSource>, IEnumerableEx<TData>> _converter;

		public Stream Stream { get { return _reader.Stream; } }

		public IMarketDataMetaInfo MetaInfo { get { return _reader.MetaInfo; } }

		public ConvertableDataStorageReader(IDataStorageReader<TSource> reader, Func<IEnumerableEx<TSource>, IEnumerableEx<TData>> converter)
		{
			if (reader == null)
				throw new ArgumentNullException("reader");

			if (converter == null)
				throw new ArgumentNullException("converter");

			_reader = reader;
			_converter = converter;
		}

		public IEnumerableEx<TData> Load()
		{
			return _converter(_reader.Load());
		}

		protected override void DisposeManaged()
		{
			_reader.Dispose();
			base.DisposeManaged();
		}
	}
}