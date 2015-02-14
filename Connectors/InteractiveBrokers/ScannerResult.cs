namespace StockSharp.InteractiveBrokers
{
	using StockSharp.Messages;

	/// <summary>
	/// ��������� ������� �������, ������������ ����� <see cref="IBTrader.SubscribeScanner"/>.
	/// </summary>
	public class ScannerResult
	{
		/// <summary>
		/// ������������� �����������.
		/// </summary>
		public SecurityId SecurityId { get; set; }
		
		/// <summary>
		/// ����.
		/// </summary>
		public int Rank { get; set; }
		
		/// <summary>
		/// �������� �������.
		/// </summary>
		public string Distance { get; set; }

		/// <summary>
		/// �������� �������.
		/// </summary>
		public string Benchmark { get; set; }

		/// <summary>
		/// �������� �������.
		/// </summary>
		public string Projection { get; set; }

		/// <summary>
		/// �������� ���������������� �����������.
		/// </summary>
		public string Legs { get; set; }
	}
}