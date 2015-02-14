namespace StockSharp.Algo.Storages
{
	using StockSharp.BusinessEntities;

	/// <summary>
	/// ��������� ��� ������� � ��������� ������������.
	/// </summary>
	public interface IStorageSecurityList : ISecurityList, IStorageEntityList<Security>, ISecurityStorage
	{
	}
}