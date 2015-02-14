namespace StockSharp.Algo.Storages
{
	using Ecng.Serialization;

	using StockSharp.BusinessEntities;

	/// <summary>
	/// ����� ��� ������������� � ���� ������ ������, ���������� �� ������� ���������.
	/// </summary>
	public class OrderList : BaseStorageEntityList<Order>
	{
		/// <summary>
		/// ������� <see cref="OrderList"/>.
		/// </summary>
		/// <param name="storage">����������� ��������� ��� ������� ������� � ���������.</param>
		public OrderList(IStorage storage)
			: base(storage)
		{
		}
	}
}