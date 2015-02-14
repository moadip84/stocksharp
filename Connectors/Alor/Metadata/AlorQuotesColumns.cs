namespace StockSharp.Alor.Metadata
{
	/// <summary>
	/// ������� ��������� ������� ORDERBOOK.
	/// </summary>
	public static class AlorQuotesColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.Quote, "ID", typeof(int));

		/// <summary>
		/// ������������� ������ ������ ��� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityBoard = new AlorColumn(AlorTableTypes.Quote, "SecBoard", typeof(string), false);

		/// <summary>
		/// ������������� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityCode = new AlorColumn(AlorTableTypes.Quote, "SecCode", typeof(string), false);

		/// <summary>
		/// �������������� ���������.
		/// </summary>
		public static readonly AlorColumn Direction = new AlorColumn(AlorTableTypes.Quote, "BuySell", typeof(string));

		/// <summary>
		/// ���� ���������.
		/// </summary>
		public static readonly AlorColumn Price = new AlorColumn(AlorTableTypes.Quote, "Price", typeof(decimal));

		/// <summary>
		/// ���������� ������ �����, ���������� � �����.
		/// </summary>
		public static readonly AlorColumn Volume = new AlorColumn(AlorTableTypes.Quote, "Quantity", typeof(int));
	}
}