namespace StockSharp.Algo.Storages
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;

	using Ecng.Collections;

	/// <summary>
	/// ������������.
	/// </summary>
	public interface IMarketDataSerializer
	{
		/// <summary>
		/// ������� ������ ����-����������.
		/// </summary>
		/// <param name="date">����.</param>
		/// <returns>����-���������� � ������ �� ���� ����.</returns>
		IMarketDataMetaInfo CreateMetaInfo(DateTime date);

		/// <summary>
		/// ������������� ������ � ����� ������.
		/// </summary>
		/// <param name="data">������.</param>
		/// <param name="metaInfo">����-���������� � ������ �� ���� ����.</param>
		/// <returns>����� ������.</returns>
		byte[] Serialize(IEnumerable data, IMarketDataMetaInfo metaInfo);

		/// <summary>
		/// ��������� ������ �� ������.
		/// </summary>
		/// <param name="stream">������.</param>
		/// <param name="metaInfo">����-���������� � ������ �� ���� ����.</param>
		/// <returns>������.</returns>
		IEnumerableEx Deserialize(Stream stream, IMarketDataMetaInfo metaInfo);
	}

	/// <summary>
	/// ������������.
	/// </summary>
	/// <typeparam name="TData">��� ������.</typeparam>
	public interface IMarketDataSerializer<TData> : IMarketDataSerializer
	{
		/// <summary>
		/// ������������� ������ � ����� ������.
		/// </summary>
		/// <param name="data">������.</param>
		/// <param name="metaInfo">����-���������� � ������ �� ���� ����.</param>
		/// <returns>����� ����.</returns>
		byte[] Serialize(IEnumerable<TData> data, IMarketDataMetaInfo metaInfo);

		/// <summary>
		/// ��������� ������ �� ������.
		/// </summary>
		/// <param name="stream">�����.</param>
		/// <param name="metaInfo">����-���������� � ������ �� ���� ����.</param>
		/// <returns>������.</returns>
		new IEnumerableEx<TData> Deserialize(Stream stream, IMarketDataMetaInfo metaInfo);

		/// <summary>
		/// ��������� ������ �� ������.
		/// </summary>
		/// <param name="reader">����������� ������.</param>
		/// <returns>������.</returns>
		IEnumerableEx<TData> Deserialize(IDataStorageReader<TData> reader);
	}
}