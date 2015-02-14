namespace StockSharp.Algo.Storages
{
	using Ecng.Serialization;

	using StockSharp.BusinessEntities;

	/// <summary>
	/// ����� ��� ������������� � ���� ������ ������� ������, ���������� �� ������� ���������.
	/// </summary>
	public class TradeList : BaseStorageEntityList<Trade>
	{
		/// <summary>
		/// ������� <see cref="TradeList"/>.
		/// </summary>
		/// <param name="storage">����������� ��������� ��� ������� ������� � ���������.</param>
		public TradeList(IStorage storage)
			: base(storage)
		{
		}
	}
}