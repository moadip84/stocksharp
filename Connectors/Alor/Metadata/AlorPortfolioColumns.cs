namespace StockSharp.Alor.Metadata
{
	/// <summary>
	/// ������� ��������� ������� TRDACC.
	/// </summary>
	public static class AlorPortfolioColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.Portfolio, "ID", typeof(int), false);

		/// <summary>
		/// ����� ��������� �����.
		/// </summary>
		public static readonly AlorColumn Account = new AlorColumn(AlorTableTypes.Portfolio, "Account", typeof(string));

		/// <summary>
		/// ������������ ��������� �����.
		/// </summary>
		public static readonly AlorColumn Name = new AlorColumn(AlorTableTypes.Portfolio, "Name", typeof(string), false);

		/// <summary>
		/// ��� ��������� �����.
		/// </summary>
		public static readonly AlorColumn Type = new AlorColumn(AlorTableTypes.Portfolio, "Type", typeof(string), false);

		/// <summary>
		/// ��� ����������� �����.
		/// </summary>
		public static readonly AlorColumn BankAccount = new AlorColumn(AlorTableTypes.Portfolio, "BankAccount", typeof(string), false);

		/// <summary>
		/// ��� ������������� �����.
		/// </summary>
		public static readonly AlorColumn DepoAccount = new AlorColumn(AlorTableTypes.Portfolio, "DepoAccount", typeof(string), false);

		/// <summary>
		/// ����������� ������������ �����.
		/// </summary>
		public static readonly AlorColumn BankName = new AlorColumn(AlorTableTypes.Portfolio, "BankCode", typeof(string), false);

		/// <summary>
		/// ����������� ������������ �����������.
		/// </summary>
		public static readonly AlorColumn DepoName = new AlorColumn(AlorTableTypes.Portfolio, "DepoCode", typeof(string), false);
	}
}