namespace StockSharp.Algo
{
	using System;

	using StockSharp.Messages;

	/// <summary>
	/// ��������� � ������ �������. ������������ ��� CSV ������.
	/// </summary>
	public class TimeQuoteChange : QuoteChange
	{
		/// <summary>
		/// ������� <see cref="TimeQuoteChange"/>.
		/// </summary>
		public TimeQuoteChange()
		{
		}

		/// <summary>
		/// ������� <see cref="TimeQuoteChange"/>.
		/// </summary>
		/// <param name="quote">���������, �� ������� ����� ����������� ���������.</param>
		/// <param name="message">��������� � �����������.</param>
		public TimeQuoteChange(QuoteChange quote, QuoteChangeMessage message)
		{
			if (quote == null)
				throw new ArgumentNullException("quote");

			SecurityId = message.SecurityId;
			ServerTime = message.ServerTime;
			LocalTime = message.LocalTime;
			Price = quote.Price;
			Volume = quote.Volume;
			Side = quote.Side;
		}

		/// <summary>
		/// ������������� �����������.
		/// </summary>
		public SecurityId SecurityId { get; set; }

		/// <summary>
		/// ��������� ����� �������.
		/// </summary>
		public DateTimeOffset ServerTime { get; set; }

		/// <summary>
		/// ��������� ����� �������.
		/// </summary>
		public DateTime LocalTime { get; set; }
	}
}