namespace StockSharp.Algo.Testing
{
	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// ������� ����������� ��������.
	/// </summary>
	public abstract class BaseEmulationConnector : Connector
	{
		private readonly EmulationMessageAdapter _adapter;

		/// <summary>
		/// ���������������� <see cref="BaseEmulationConnector"/>.
		/// </summary>
		protected BaseEmulationConnector()
		{
			TransactionAdapter = _adapter = new EmulationMessageAdapter(new MarketEmulator(), new PassThroughSessionHolder(TransactionIdGenerator));
		}

		/// <summary>
		/// �������������� �� ��������������� ������ ����� ����� <see cref="IConnector.ReRegisterOrder(StockSharp.BusinessEntities.Order,StockSharp.BusinessEntities.Order)"/>
		/// � ���� ����� ����������.
		/// </summary>
		public override bool IsSupportAtomicReRegister
		{
			get { return MarketEmulator.Settings.IsSupportAtomicReRegister; }
		}

		/// <summary>
		/// �������� ������.
		/// </summary>
		public IMarketEmulator MarketEmulator
		{
			get { return _adapter.Emulator; }
			set { _adapter.Emulator = value; }
		}

		/// <summary>
		/// ���������� ���������, ���������� �������� ������.
		/// </summary>
		/// <param name="message">���������, ���������� �������� ������.</param>
		/// <param name="adapterType">��� ��������, �� �������� ������ ���������.</param>
		/// <param name="direction">����������� ���������.</param>
		protected override void OnProcessMessage(Message message, MessageAdapterTypes adapterType, MessageDirections direction)
		{
			if (adapterType == MessageAdapterTypes.MarketData && direction == MessageDirections.Out)
			{
				switch (message.Type)
				{
					case MessageTypes.Connect:
					case MessageTypes.Disconnect:
					case MessageTypes.MarketData:
					case MessageTypes.Error:
					case MessageTypes.SecurityLookupResult:
					case MessageTypes.PortfolioLookupResult:
						base.OnProcessMessage(message, adapterType, direction);
						break;

					case MessageTypes.Execution:
					{
						var execMsg = (ExecutionMessage)message;

						if (execMsg.ExecutionType != ExecutionTypes.Trade)
							TransactionAdapter.SendInMessage(message);
						else
							base.OnProcessMessage(message, adapterType, direction);

						break;
					}

					default:
						TransactionAdapter.SendInMessage(message);
						break;
				}
			}
			else
				base.OnProcessMessage(message, adapterType, direction);
		}
	}
}