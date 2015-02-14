namespace StockSharp.Algo.Storages
{
	using Ecng.Serialization;

	using StockSharp.BusinessEntities;

	/// <summary>
	/// ����� ��� ������������� � ���� ������ ��������, ���������� �� ������� ���������.
	/// </summary>
	public class NewsList : BaseStorageEntityList<News>
	{
		/// <summary>
		/// ������� <see cref="NewsList"/>.
		/// </summary>
		/// <param name="storage">����������� ��������� ��� ������� ������� � ���������.</param>
		public NewsList(IStorage storage)
			: base(storage)
		{
		}
	}
}