namespace StockSharp.Algo.Strategies
{
	using System;

	/// <summary>
	/// ���������� ������ ����� �������� �������� ���������.
	/// </summary>
	public enum ProcessResults
	{
		/// <summary>
		/// ���������� ������ ������.
		/// </summary>
		Continue,

		/// <summary>
		/// ���������� ������ ���������.
		/// </summary>
		Stop,
	}

	/// <summary>
	/// �������� ���������, ���������� �� ����-������.
	/// </summary>
	public abstract class TimeFrameStrategy : Strategy
	{
	    /// <summary>
	    /// ���������������� <see cref="TimeFrameStrategy"/>.
	    /// </summary>
	    /// <param name="timeFrame">��������� ���������.</param>
	    protected TimeFrameStrategy(TimeSpan timeFrame)
		{
			_interval = this.Param("Interval", timeFrame);
			_timeFrame = this.Param("TimeFrame", timeFrame);
		}

		private readonly StrategyParam<TimeSpan> _timeFrame;

        /// <summary>
        /// ��������� ���������.
        /// </summary>
        public TimeSpan TimeFrame
        {
			get { return _timeFrame.Value; }
            set { _timeFrame.Value = value; }
        }

		private readonly StrategyParam<TimeSpan> _interval;

		/// <summary>
		/// �������� ������� ���������. �� ��������� ����� <see cref="TimeFrame"/>.
		/// </summary>
		public TimeSpan Interval
		{
			get { return _interval.Value; }
			set { _interval.Value = value; }
		}

		/// <summary>
		/// ����� ���������� �����, ����� �������� ����� <see cref="Strategy.Start"/>, � ��������� <see cref="Strategy.ProcessState"/> ������� � �������� <see cref="ProcessStates.Started"/>.
		/// </summary>
		protected override void OnStarted()
		{
			base.OnStarted();

			SafeGetConnector()
				.WhenIntervalElapsed(Interval/*, true*/)
				.Do(() =>
				{
					var result = OnProcess();

					if (result == ProcessResults.Stop)
						Stop();
				})
				.Until(() =>
				{
					if (ProcessState == ProcessStates.Stopping)
						return OnProcess() == ProcessResults.Stop;

					return false;
				})
				.Apply(this);
		}

		/// <summary>
		/// ���������� ��������� ���������.
		/// </summary>
		/// <returns>
		/// ��������� ������ ����� �������� ��������� ���������.
		/// </returns>
		protected abstract ProcessResults OnProcess();
	}
}