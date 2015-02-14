namespace StockSharp.InteractiveBrokers.Web
{
	using StockSharp.Messages;

	/// <summary>
	/// ��������� ���������� �� �����������.
	/// </summary>
	public class ProductDescripton
	{
		/// <summary>
		/// ��������.
		/// </summary>
		public string Name;

		/// <summary>
		/// ���.
		/// </summary>
		public string Symbol;

		/// <summary>
		/// ���.
		/// </summary>
		public SecurityTypes Type;

		/// <summary>
		/// ������.
		/// </summary>
		public string Country;

		/// <summary>
		/// ���� ��������.
		/// </summary>
		public decimal ClosingPrice;

		/// <summary>
		/// ������.
		/// </summary>
		public string Currency;

		/// <summary>
		/// ������� �����.
		/// </summary>
		public string AssetId;

		/// <summary>
		/// ��� �����.
		/// </summary>
		public string StockType;

		/// <summary>
		/// ������������ �����������.
		/// </summary>
		public string InitialMargin;

		/// <summary>
		/// ������������ �����������.
		/// </summary>
		public string MaintenanceMargin;

		/// <summary>
		/// ������������ ����������� ��� �������� �������.
		/// </summary>
		public string ShortMargin;
	}
}