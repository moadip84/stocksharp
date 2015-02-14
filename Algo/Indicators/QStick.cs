namespace StockSharp.Algo.Indicators
{
	using StockSharp.Algo.Candles;

	/// <summary>
	/// QStick.
	/// </summary>
	/// <remarks>
	/// http://www2.wealth-lab.com/WL5Wiki/QStick.ashx
	/// </remarks>
	public class QStick : LengthIndicator<IIndicatorValue>
	{
		private readonly SimpleMovingAverage _sma;

		/// <summary>
		/// ������� <see cref="QStick"/>.
		/// </summary>
		public QStick()
			: base(typeof(Candle))
		{
			_sma = new SimpleMovingAverage();
			Length = 15;
		}

		/// <summary>
		/// ����������� �� ���������.
		/// </summary>
		public override bool IsFormed { get { return _sma.IsFormed; } }

		/// <summary>
		/// �������� ��������� ���������� �� ��������������. ����� ���������� ������ ���, ����� �������� �������������� ��������� (��������, ����� �������).
		/// </summary>
		public override void Reset()
		{
			_sma.Length = Length;
			base.Reset();
		}

		/// <summary>
		/// ���������� ������� ��������.
		/// </summary>
		/// <param name="input">������� ��������.</param>
		/// <returns>�������������� ��������.</returns>
		protected override IIndicatorValue OnProcess(IIndicatorValue input)
		{
			var candle = input.GetValue<Candle>();
			return _sma.Process(input.SetValue(this, candle.OpenPrice - candle.ClosePrice));
		}
	}
}