namespace StockSharp.InteractiveBrokers.Web
{
	/// <summary>
	/// ���������� �� ����������� �� ���������� ��������.
	/// </summary>
	public class ProductBoard
	{
		/// <summary>
		/// ������ ����.
		/// </summary>
		public string Markets;

		/// <summary>
		/// ���������� �������������.
		/// </summary>
		public string Id;

		/// <summary>
		/// ��������.
		/// </summary>
		public string Name;

		/// <summary>
		/// �����.
		/// </summary>
		public string Class;

		/// <summary>
		/// �����������.
		/// </summary>
		public string SettlementMethod;

		/// <summary>
		/// ���� �����.
		/// </summary>
		public string ExchangeWebsite;

		/// <summary>
		/// ���� ��������.
		/// </summary>
		public string[] TradingHours;

		/// <summary>
		/// ������� ��������.
		/// </summary>
		public string PriceRange1;

		/// <summary>
		/// ������� ��������.
		/// </summary>
		public string PriceRange2;

		/// <summary>
		/// ������� ��������.
		/// </summary>
		public string PriceRange3;

		/// <summary>
		/// ���� ��������.
		/// </summary>
		public decimal VolumeRange1;

		/// <summary>
		/// ���� ��������.
		/// </summary>
		public decimal VolumeRange2;

		/// <summary>
		/// ���� ��������.
		/// </summary>
		public decimal VolumeRange3;
	}
}