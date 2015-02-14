namespace StockSharp.Xaml
{
	using System;
	using System.Collections.Generic;

	using Ecng.Common;
	using Ecng.Xaml;

	using StockSharp.Logging;
	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// ���������������� �����������. ����������� ������ <see cref="IConnector"/> �������� ����������� ��� ����, ����� ��� ������� ��������� � GUI ������.
	/// </summary>
	/// <typeparam name="TUnderlyingConnector">��� �����������, ������� ���������� ��������������.</typeparam>
	public class GuiConnector<TUnderlyingConnector> : BaseLogReceiver, IConnector
		where TUnderlyingConnector : IConnector
	{
		/// <summary>
		/// ������� ���������������� �����������.
		/// </summary>
		/// <param name="connector">�����������, ������� ���������� �������� � <see cref="GuiConnector{T}"/>.</param>
		public GuiConnector(TUnderlyingConnector connector)
		{
			Connector = connector;
		}

		private TUnderlyingConnector _connector;

		/// <summary>
		/// ������������������ ������ �����������.
		/// </summary>
		public TUnderlyingConnector Connector
		{
			get { return _connector; }
			private set
			{
				if (value.IsNull())
					throw new ArgumentNullException();

				_connector = value;

				Connector.NewPortfolios += NewPortfoliosHandler;
				Connector.PortfoliosChanged += PortfoliosChangedHandler;
				Connector.NewPositions += NewPositionsHandler;
				Connector.PositionsChanged += PositionsChangedHandler;
				Connector.NewSecurities += NewSecuritiesHandler;
				Connector.SecuritiesChanged += SecuritiesChangedHandler;
				Connector.NewTrades += NewTradesHandler;
				Connector.NewMyTrades += NewMyTradesHandler;
				Connector.NewOrders += NewOrdersHandler;
				Connector.OrdersChanged += OrdersChangedHandler;
				Connector.OrdersRegisterFailed += OrdersRegisterFailedHandler;
				Connector.OrdersCancelFailed += OrdersCancelFailedHandler;
				Connector.NewStopOrders += NewStopOrdersHandler;
				Connector.StopOrdersChanged += StopOrdersChangedHandler;
				Connector.StopOrdersRegisterFailed += StopOrdersRegisterFailedHandler;
				Connector.StopOrdersCancelFailed += StopOrdersCancelFailedHandler;
				Connector.NewMarketDepths += NewMarketDepthsHandler;
				Connector.MarketDepthsChanged += MarketDepthsChangedHandler;
				Connector.NewOrderLogItems += NewOrderLogItemsHandler;
				Connector.NewNews += NewNewsHandler;
				Connector.NewsChanged += NewsChangedHandler;
				Connector.NewMessage += NewMessageHandler;
				Connector.Connected += ConnectedHandler;
				Connector.Disconnected += DisconnectedHandler;
				Connector.ConnectionError += ConnectionErrorHandler;
				Connector.ExportStarted += ExportStartedHandler;
				Connector.ExportStopped += ExportStoppedHandler;
				Connector.ExportError += ExportErrorHandler;
				Connector.NewDataExported += NewDataExportedHandler;
				Connector.ProcessDataError += ProcessDataErrorHandler;
				Connector.MarketTimeChanged += MarketTimeChangedHandler;
				Connector.LookupSecuritiesResult += LookupSecuritiesResultHandler;
				Connector.LookupPortfoliosResult += LookupPortfoliosResultHandler;
				Connector.MarketDataSubscriptionSucceeded += MarketDataSubscriptionSucceededHandler;
				Connector.MarketDataSubscriptionFailed += MarketDataSubscriptionFailedHandler;
				Connector.SessionStateChanged += SessionStateChangedHandler;
				Connector.ValuesChanged += ValuesChangedHandler;
			}
		}

		#region NewPortfolios

		/// <summary>
		/// ������� ��������� ����� ���������.
		/// </summary>
		public event Action<IEnumerable<Portfolio>> NewPortfolios;

		private void NewPortfoliosHandler(IEnumerable<Portfolio> portfolios)
		{
			AddGuiAction(() => NewPortfolios.SafeInvoke(portfolios));
		}

		#endregion

		#region PortfoliosChanged

		/// <summary>
		/// ������� ��������� ���������� ���������.
		/// </summary>
		public event Action<IEnumerable<Portfolio>> PortfoliosChanged;

		private void PortfoliosChangedHandler(IEnumerable<Portfolio> portfolios)
		{
			AddGuiAction(() => PortfoliosChanged.SafeInvoke(portfolios));
		}

		#endregion

		#region NewPositions

		/// <summary>
		/// ������� ��������� ����� �������.
		/// </summary>
		public event Action<IEnumerable<Position>> NewPositions;

		private void NewPositionsHandler(IEnumerable<Position> positions)
		{
			AddGuiAction(() => NewPositions.SafeInvoke(positions));
		}

		#endregion

		#region PositionsChanged

		/// <summary>
		/// ������� ��������� ���������� �������.
		/// </summary>
		public event Action<IEnumerable<Position>> PositionsChanged;

		private void PositionsChangedHandler(IEnumerable<Position> positions)
		{
			AddGuiAction(() => PositionsChanged.SafeInvoke(positions));
		}

		#endregion

		#region NewSecurities

		/// <summary>
		/// ������� ��������� ����� ������������.
		/// </summary>
		public event Action<IEnumerable<Security>> NewSecurities;

		private void NewSecuritiesHandler(IEnumerable<Security> securities)
		{
			AddGuiAction(() => NewSecurities.SafeInvoke(securities));
		}

		#endregion

		#region SecuritiesChanged

		/// <summary>
		/// ������� ��������� ���������� ������������.
		/// </summary>
		public event Action<IEnumerable<Security>> SecuritiesChanged;

		private void SecuritiesChangedHandler(IEnumerable<Security> securities)
		{
			AddGuiAction(() => SecuritiesChanged.SafeInvoke(securities));
		}

		#endregion

		#region NewTrades

		/// <summary>
		/// ������� ��������� ���� ����� ������.
		/// </summary>
		public event Action<IEnumerable<Trade>> NewTrades;

		private void NewTradesHandler(IEnumerable<Trade> trades)
		{
			AddGuiAction(() => NewTrades.SafeInvoke(trades));
		}

		#endregion

		#region NewMyTrades

		/// <summary>
		/// ������� ��������� ����������� ����� ������.
		/// </summary>
		public event Action<IEnumerable<MyTrade>> NewMyTrades;

		private void NewMyTradesHandler(IEnumerable<MyTrade> trades)
		{
			AddGuiAction(() => NewMyTrades.SafeInvoke(trades));
		}

		#endregion

		#region NewOrders

		/// <summary>
		/// ������� ��������� ����� ������.
		/// </summary>
		public event Action<IEnumerable<Order>> NewOrders;

		private void NewOrdersHandler(IEnumerable<Order> orders)
		{
			AddGuiAction(() => NewOrders.SafeInvoke(orders));
		}

		#endregion

		#region OrdersChanged

		/// <summary>
		/// ������� ��������� ��������� ������ (�����, �������������).
		/// </summary>
		public event Action<IEnumerable<Order>> OrdersChanged;

		private void OrdersChangedHandler(IEnumerable<Order> orders)
		{
			AddGuiAction(() => OrdersChanged.SafeInvoke(orders));
		}

		#endregion

		#region OrdersRegisterFailed

		/// <summary>
		/// ������� �� �������, ��������� � ������������ ������.
		/// </summary>
		public event Action<IEnumerable<OrderFail>> OrdersRegisterFailed;

		private void OrdersRegisterFailedHandler(IEnumerable<OrderFail> fails)
		{
			AddGuiAction(() => OrdersRegisterFailed.SafeInvoke(fails));
		}

		#endregion

		#region OrdersCancelFailed

		/// <summary>
		/// ������� �� �������, ��������� �� ������� ������.
		/// </summary>
		public event Action<IEnumerable<OrderFail>> OrdersCancelFailed;

		private void OrdersCancelFailedHandler(IEnumerable<OrderFail> fails)
		{
			AddGuiAction(() => OrdersCancelFailed.SafeInvoke(fails));
		}

		#endregion

		#region NewStopOrders

		/// <summary>
		/// ������� ��������� ����� ����-������.
		/// </summary>
		public event Action<IEnumerable<Order>> NewStopOrders;

		private void NewStopOrdersHandler(IEnumerable<Order> orders)
		{
			AddGuiAction(() => NewStopOrders.SafeInvoke(orders));
		}

		#endregion

		#region StopOrdersChanged

		/// <summary>
		/// ������� ��������� ����� ����-������.
		/// </summary>
		public event Action<IEnumerable<Order>> StopOrdersChanged;

		private void StopOrdersChangedHandler(IEnumerable<Order> orders)
		{
			AddGuiAction(() => StopOrdersChanged.SafeInvoke(orders));
		}

		#endregion

		#region StopOrdersRegisterFailed

		/// <summary>
		/// ������� �� �������, ��������� � ������������ ����-������.
		/// </summary>
		public event Action<IEnumerable<OrderFail>> StopOrdersRegisterFailed;

		private void StopOrdersRegisterFailedHandler(IEnumerable<OrderFail> fails)
		{
			AddGuiAction(() => StopOrdersRegisterFailed.SafeInvoke(fails));
		}

		#endregion

		#region StopOrdersCancelFailed

		/// <summary>
		/// ������� �� �������, ��������� �� ������� ����-������.
		/// </summary>
		public event Action<IEnumerable<OrderFail>> StopOrdersCancelFailed;

		private void StopOrdersCancelFailedHandler(IEnumerable<OrderFail> fails)
		{
			AddGuiAction(() => StopOrdersCancelFailed.SafeInvoke(fails));
		}

		#endregion

		#region NewMarketDepths

		/// <summary>
		/// ������� ��������� ����� �������� � �����������.
		/// </summary>
		public event Action<IEnumerable<MarketDepth>> NewMarketDepths;

		private void NewMarketDepthsHandler(IEnumerable<MarketDepth> marketDepths)
		{
			AddGuiAction(() => NewMarketDepths.SafeInvoke(marketDepths));
		}

		#endregion

		#region MarketDepthsChanged

		/// <summary>
		/// ������� ��������� �������� � �����������.
		/// </summary>
		public event Action<IEnumerable<MarketDepth>> MarketDepthsChanged;

		private void MarketDepthsChangedHandler(IEnumerable<MarketDepth> marketDepths)
		{
			AddGuiAction(() => MarketDepthsChanged.SafeInvoke(marketDepths));
		}

		#endregion

		#region NewOrderLogItems

		/// <summary>
		/// ������� ��������� ����� ������� � ���� ������.
		/// </summary>
		public event Action<IEnumerable<OrderLogItem>> NewOrderLogItems;

		private void NewOrderLogItemsHandler(IEnumerable<OrderLogItem> items)
		{
			AddGuiAction(() => NewOrderLogItems.SafeInvoke(items));
		}

		#endregion

		#region NewNews

		/// <summary>
		/// ������� ��������� �������.
		/// </summary>
		public event Action<News> NewNews;

		private void NewNewsHandler(News news)
		{
			AddGuiAction(() => NewNews.SafeInvoke(news));
		}

		#endregion

		#region NewsChanged

		/// <summary>
		/// ������� ��������� ������� (��������, ��� ���������� ������ <see cref="StockSharp.BusinessEntities.News.Story"/>).
		/// </summary>
		public event Action<News> NewsChanged;

		private void NewsChangedHandler(News news)
		{
			AddGuiAction(() => NewsChanged.SafeInvoke(news));
		}

		#endregion

		#region NewMessage

		/// <summary>
		/// ������� ��������� ������ ��������� <see cref="Message"/>.
		/// </summary>
		public event Action<Message, MessageDirections> NewMessage;

		private void NewMessageHandler(Message message, MessageDirections direction)
		{
			AddGuiAction(() => NewMessage.SafeInvoke(message, direction));
		}

		#endregion

		#region Connected

		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		public event Action Connected;

		private void ConnectedHandler()
		{
			AddGuiAction(() => Connected.SafeInvoke());
		}

		#endregion

		#region Disconnected

		/// <summary>
		/// ������� ��������� ����������.
		/// </summary>
		public event Action Disconnected;

		private void DisconnectedHandler()
		{
			AddGuiAction(() => Disconnected.SafeInvoke());
		}

		#endregion

		#region ConnectionError

		/// <summary>
		/// ������� ������ ����������� (��������, ���������� ���� ���������).
		/// </summary>
		public event Action<Exception> ConnectionError;

		private void ConnectionErrorHandler(Exception exception)
		{
			AddGuiAction(() => ConnectionError.SafeInvoke(exception));
		}

		#endregion

		#region NewDataExported

		/// <summary>
		/// �������, ��������������� � ����� �������������� ������.
		/// </summary>
		public event Action NewDataExported;

		private void NewDataExportedHandler()
		{
			AddGuiAction(() => NewDataExported.SafeInvoke());
		}

		#endregion

		#region ProcessDataError

		/// <summary>
		/// �������, ��������������� �� ������ ��� ��������� ��� ��������� ����� ������ � �������.
		/// </summary>
		public event Action<Exception> ProcessDataError;

		private void ProcessDataErrorHandler(Exception exception)
		{
			AddGuiAction(() => ProcessDataError.SafeInvoke(exception));
		}

		#endregion

		#region MarketTimeChanged

		/// <summary>
		/// �������, ��������������� �� ��������� �������� ������� �� �������� ��������� <see cref="IConnector.ExchangeBoards"/>.
		/// ���������� ������� �� �������, ��������� � ���������� ������ �������. ������ ��� ������� �������� �������� <see cref="TimeSpan.Zero"/>.
		/// </summary>
		public event Action<TimeSpan> MarketTimeChanged;

		private void MarketTimeChangedHandler(TimeSpan diff)
		{
			AddGuiAction(() => MarketTimeChanged.SafeInvoke(diff));
		}

		#endregion

		#region LookupSecuritiesResult

		/// <summary>
		/// �������, ���������� ��������� ������, ����������� ����� ����� <see cref="LookupSecurities(StockSharp.BusinessEntities.Security)"/>.
		/// </summary>
		public event Action<IEnumerable<Security>> LookupSecuritiesResult;

		private void LookupSecuritiesResultHandler(IEnumerable<Security> securities)
		{
			AddGuiAction(() => LookupSecuritiesResult.SafeInvoke(securities));
		}

		#endregion

		#region LookupPortfoliosResult

		/// <summary>
		/// �������, ���������� ��������� ������, ����������� ����� ����� <see cref="LookupPortfolios"/>.
		/// </summary>
		public event Action<IEnumerable<Portfolio>> LookupPortfoliosResult;

		private void LookupPortfoliosResultHandler(IEnumerable<Portfolio> portfolios)
		{
			AddGuiAction(() => LookupPortfoliosResult.SafeInvoke(portfolios));
		}

		#endregion

		#region MarketDataSubscriptionSucceeded

		/// <summary>
		/// ������� �������� ����������� ����������� ��� ��������� ������-������.
		/// </summary>
		public event Action<Security, MarketDataTypes> MarketDataSubscriptionSucceeded;

		private void MarketDataSubscriptionSucceededHandler(Security security, MarketDataTypes type)
		{
			AddGuiAction(() => MarketDataSubscriptionSucceeded.SafeInvoke(security, type));
		}

		#endregion

		#region MarketDataSubscriptionFailed

		/// <summary>
		/// ������� ������ ����������� ����������� ��� ��������� ������-������.
		/// </summary>
		public event Action<Security, MarketDataTypes, Exception> MarketDataSubscriptionFailed;

		private void MarketDataSubscriptionFailedHandler(Security security, MarketDataTypes type, Exception error)
		{
			AddGuiAction(() => MarketDataSubscriptionFailed.SafeInvoke(security, type, error));
		}

		#endregion

		#region ExportStarted

		/// <summary>
		/// ������� ��������� ������� ��������.
		/// </summary>
		public event Action ExportStarted;

		private void ExportStartedHandler()
		{
			AddGuiAction(() => ExportStarted.SafeInvoke());
		}

		#endregion

		#region ExportStopped

		/// <summary>
		/// ������� �������� ��������� ��������.
		/// </summary>
		public event Action ExportStopped;

		private void ExportStoppedHandler()
		{
			AddGuiAction(() => ExportStopped.SafeInvoke());
		}

		#endregion

		#region ExportError

		/// <summary>
		/// ������� ������ �������� (��������, ���������� ���� ���������).
		/// </summary>
		public event Action<Exception> ExportError;

		private void ExportErrorHandler(Exception exception)
		{
			AddGuiAction(() => ExportError.SafeInvoke(exception));
		}

		#endregion

		#region SessionStateChanged

		/// <summary>
		/// ������� ��������� ��������� ������ ��� �������� ��������.
		/// </summary>
		public event Action<ExchangeBoard, SessionStates> SessionStateChanged;

		private void SessionStateChangedHandler(ExchangeBoard board, SessionStates state)
		{
			AddGuiAction(() => SessionStateChanged.SafeInvoke(board, state));
		}

		#endregion

		private static void AddGuiAction(Action action)
		{
			GuiDispatcher.GlobalDispatcher.AddAction(action);
		}

		/// <summary>
		/// �������� ��������� ������ ��� �������� ��������.
		/// </summary>
		/// <param name="board">�������� �������� ����������� ������.</param>
		/// <returns>��������� ������. ���� ���������� � ��������� ������ �����������, �� ����� ���������� <see langword="null"/>.</returns>
		public SessionStates? GetSessionState(ExchangeBoard board)
		{
			return Connector.GetSessionState(board);
		}

		/// <summary>
		/// ������ ���� �������� ��������, ��� ������� ��������� ����������� <see cref="IConnector.Securities"/>.
		/// </summary>
		public IEnumerable<ExchangeBoard> ExchangeBoards
		{
			get { return Connector.ExchangeBoards; }
		}

		/// <summary>
		/// ������ ���� ����������� ������������.
		/// �������� ���������� ����� ����, ��� ������ ������� <see cref="IConnector.NewSecurities" />. ����� ����� ���������� ������ ���������.
		/// </summary>
		public IEnumerable<Security> Securities
		{
			get { return Connector.Securities; }
		}

		/// <summary>
		/// �������� ��� ������.
		/// </summary>
		public IEnumerable<Order> Orders
		{
			get { return Connector.Orders; }
		}

		/// <summary>
		/// �������� ��� ����-������.
		/// </summary>
		public IEnumerable<Order> StopOrders
		{
			get { return Connector.StopOrders; }
		}

		/// <summary>
		/// �������� ��� ������ ��� ����������� ������.
		/// </summary>
		public IEnumerable<OrderFail> OrderRegisterFails
		{
			get { return Connector.OrderRegisterFails; }
		}

		/// <summary>
		/// �������� ��� ������ ��� ������ ������.
		/// </summary>
		public IEnumerable<OrderFail> OrderCancelFails
		{
			get { return Connector.OrderCancelFails; }
		}

		/// <summary>
		/// �������� ��� ������.
		/// </summary>
		public IEnumerable<Trade> Trades
		{
			get { return Connector.Trades; }
		}

		/// <summary>
		/// �������� ��� ����������� ������.
		/// </summary>
		public IEnumerable<MyTrade> MyTrades
		{
			get { return Connector.MyTrades; }
		}

		/// <summary>
		/// �������� ��� ��������.
		/// </summary>
		public IEnumerable<Portfolio> Portfolios
		{
			get { return Connector.Portfolios; }
		}

		/// <summary>
		/// �������� ��� �������.
		/// </summary>
		public IEnumerable<Position> Positions
		{
			get { return Connector.Positions; }
		}

		/// <summary>
		/// ��� �������.
		/// </summary>
		public IEnumerable<News> News
		{
			get { return Connector.News; }
		}

		/// <summary>
		/// ��������� ����������.
		/// </summary>
		public ConnectionStates ConnectionState
		{
			get { return Connector.ConnectionState; }
		}

		/// <summary>
		/// ��������� ��������.
		/// </summary>
		public ConnectionStates ExportState
		{
			get { return Connector.ExportState; }
		}

		/// <summary>
		/// �������������� �� ��������������� ������ ����� ����� <see cref="IConnector.ReRegisterOrder(StockSharp.BusinessEntities.Order,StockSharp.BusinessEntities.Order)"/>
		/// � ���� ����� ����������.
		/// </summary>
		public bool IsSupportAtomicReRegister
		{
			get { return Connector.IsSupportAtomicReRegister; }
		}

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="IConnector.RegisterSecurity"/>.
		/// </summary>
		public IEnumerable<Security> RegisteredSecurities
		{
			get { return Connector.RegisteredSecurities; }
		}

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="IConnector.RegisterMarketDepth"/>.
		/// </summary>
		public IEnumerable<Security> RegisteredMarketDepths
		{
			get { return Connector.RegisteredMarketDepths; }
		}

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="IConnector.RegisterTrades"/>.
		/// </summary>
		public IEnumerable<Security> RegisteredTrades
		{
			get { return Connector.RegisteredTrades; }
		}

		/// <summary>
		/// ������ ���� ������������, ������������������ ����� <see cref="IConnector.RegisterOrderLog"/>.
		/// </summary>
		public IEnumerable<Security> RegisteredOrderLogs
		{
			get { return Connector.RegisteredOrderLogs; }
		}

		/// <summary>
		/// ������ ���� ���������, ������������������ ����� <see cref="IConnector.RegisterPortfolio"/>.
		/// </summary>
		public IEnumerable<Portfolio> RegisteredPortfolios
		{
			get { return Connector.RegisteredPortfolios; }
		}

		/// <summary>
		/// ������������ � �������� �������.
		/// </summary>
		public void Connect()
		{
			Connector.Connect();
		}

		/// <summary>
		/// ����������� �� �������� �������.
		/// </summary>
		public void Disconnect()
		{
			Connector.Disconnect();
		}

		/// <summary>
		/// ����� �����������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� ����������� ����� �������� ����� ������� <see cref="LookupSecuritiesResult"/>.
		/// </summary>
		/// <param name="criteria">����������, ���� �������� ����� �������������� � �������� �������.</param>
		public void LookupSecurities(Security criteria)
		{
			Connector.LookupSecurities(criteria);
		}

		/// <summary>
		/// ����� �����������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� ����������� ����� �������� ����� ������� <see cref="IConnector.LookupSecuritiesResult"/>.
		/// </summary>
		/// <param name="criteria">��������, ���� �������� ����� �������������� � �������� �������.</param>
		public void LookupSecurities(SecurityLookupMessage criteria)
		{
			Connector.LookupSecurities(criteria);
		}

		/// <summary>
		/// ����� ��������, ��������������� ������� <paramref name="criteria"/>.
		/// ��������� �������� ����� �������� ����� ������� <see cref="LookupPortfoliosResult"/>.
		/// </summary>
		/// <param name="criteria">��������, ���� �������� ����� �������������� � �������� �������.</param>
		public void LookupPortfolios(Portfolio criteria)
		{
			Connector.LookupPortfolios(criteria);
		}

		/// <summary>
		/// �������� ������� �� �������� � �����������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ����� ����� �������.</param>
		/// <param name="security">����������, �� �������� ����� ����� �������.</param>
		/// <param name="depoName">�������� �����������, ��� ��������� ��������� ������ ������.
		/// ��-��������� ���������� ������ ������, ��� �������� ��������� ������� �� ���� ������������.</param>
		/// <returns>�������.</returns>
		public Position GetPosition(Portfolio portfolio, Security security, string depoName = "")
		{
			return Connector.GetPosition(portfolio, security, depoName);
		}

		/// <summary>
		/// �������� ������ ���������.
		/// </summary>
		/// <param name="security">����������, �� �������� ����� �������� ������.</param>
		/// <returns>������ ���������.</returns>
		public MarketDepth GetMarketDepth(Security security)
		{
			return Connector.GetMarketDepth(security);
		}

		/// <summary>
		/// �������� ��������������� ������ ���������.
		/// </summary>
		/// <param name="security">����������, �� �������� ����� �������� ������.</param>
		/// <returns>��������������� ������ ���������.</returns>
		public MarketDepth GetFilteredMarketDepth(Security security)
		{
			return Connector.GetFilteredMarketDepth(security);
		}

		/// <summary>
		/// ����������� �� ��������� �������� ������ �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		/// <param name="type">��� �������� ������.</param>
		public void SubscribeMarketData(Security security, MarketDataTypes type)
		{
			Connector.SubscribeMarketData(security, type);
		}

		/// <summary>
		/// ���������� �� ��������� �������� ������ �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		/// <param name="type">��� �������� ������.</param>
		public void UnSubscribeMarketData(Security security, MarketDataTypes type)
		{
			Connector.UnSubscribeMarketData(security, type);
		}

		/// <summary>
		/// ������ �������� ��������� (������) �� �����������.
		/// �������� ��������� ����� �������� ����� ������� <see cref="MarketDepthsChanged"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ���������.</param>
		public void RegisterMarketDepth(Security security)
		{
			Connector.RegisterMarketDepth(security);
		}

		/// <summary>
		/// ���������� ��������� ��������� �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���������.</param>
		public void UnRegisterMarketDepth(Security security)
		{
			Connector.UnRegisterMarketDepth(security);
		}

		/// <summary>
		/// ������ �������� ��������������� ��������� (������) �� �����������.
		/// �������� ��������� ����� �������� ����� ����� <see cref="IConnector.GetFilteredMarketDepth"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ���������.</param>
		public void RegisterFilteredMarketDepth(Security security)
		{
			Connector.RegisterFilteredMarketDepth(security);
		}

		/// <summary>
		/// ���������� ��������� ��������������� ��������� �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���������.</param>
		public void UnRegisterFilteredMarketDepth(Security security)
		{
			Connector.RegisterFilteredMarketDepth(security);
		}

		/// <summary>
		/// ������ �������� ������ (������� ������) �� �����������. ����� ������ ����� ��������� �����
		/// ������� <see cref="IConnector.NewTrades"/>.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ������.</param>
		public void RegisterTrades(Security security)
		{
			Connector.RegisterTrades(security);
		}

		/// <summary>
		/// ���������� ��������� ������ (������� ������) �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ������.</param>
		public void UnRegisterTrades(Security security)
		{
			Connector.UnRegisterTrades(security);
		}

		/// <summary>
		/// ������ �������� ����� ���������� �� ��������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ���������� ������ �������� ����� ����������.</param>
		public void RegisterPortfolio(Portfolio portfolio)
		{
			Connector.RegisterPortfolio(portfolio);
		}

		/// <summary>
		/// ���������� ��������� ����� ���������� �� ��������.
		/// </summary>
		/// <param name="portfolio">��������, �� �������� ���������� ���������� ��������� ����� ����������.</param>
		public void UnRegisterPortfolio(Portfolio portfolio)
		{
			Connector.UnRegisterPortfolio(portfolio);
		}

		/// <summary>
		/// ������ �������� �������.
		/// </summary>
		public void RegisterNews()
		{
			Connector.RegisterNews();
		}

		/// <summary>
		/// ���������� ��������� ��������.
		/// </summary>
		public void UnRegisterNews()
		{
			Connector.UnRegisterNews();
		}

		/// <summary>
		/// ��������� ����� ������� <see cref="BusinessEntities.News.Story"/>. ����� ��������� ������ ����� ������� ������� <see cref="IConnector.NewsChanged"/>.
		/// </summary>
		/// <param name="news">�������.</param>
		public void RequestNewsStory(News news)
		{
			Connector.RequestNewsStory(news);
		}

		/// <summary>
		/// ������ �������� ��� ������ ��� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ��� ������.</param>
		public void RegisterOrderLog(Security security)
		{
			Connector.RegisterOrderLog(security);
		}

		/// <summary>
		/// ���������� ��������� ���� ������ ��� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ���� ������.</param>
		public void UnRegisterOrderLog(Security security)
		{
			Connector.UnRegisterOrderLog(security);
		}

		/// <summary>
		/// ������ �������� ����� ���������� (��������, <see cref="Security.LastTrade"/> ��� <see cref="Security.BestBid"/>) �� �����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ������ �������� ����� ����������.</param>
		public void RegisterSecurity(Security security)
		{
			Connector.RegisterSecurity(security);
		}

		/// <summary>
		/// ���������� ��������� ����� ����������.
		/// </summary>
		/// <param name="security">����������, �� �������� ���������� ���������� ��������� ����� ����������.</param>
		public void UnRegisterSecurity(Security security)
		{
			Connector.UnRegisterSecurity(security);
		}

		/// <summary>
		/// ���������������� ������ �� �����.
		/// </summary>
		/// <param name="order">������, ���������� ���������� ��� �����������.</param>
		public void RegisterOrder(Order order)
		{
			Connector.RegisterOrder(order);
		}

		/// <summary>
		/// ������������������ ������ �� �����.
		/// </summary>
		/// <param name="oldOrder">������, ������� ����� �����.</param>
		/// <param name="newOrder">����� ������, ������� ����� ����������������.</param>
		public void ReRegisterOrder(Order oldOrder, Order newOrder)
		{
			Connector.ReRegisterOrder(oldOrder, newOrder);
		}

		/// <summary>
		/// ������������������ ������ �� �����.
		/// </summary>
		/// <param name="oldOrder">������, ������� ����� ����� � �� ������ ��� ���������������� �����.</param>
		/// <param name="price">���� ����� ������.</param>
		/// <param name="volume">����� ����� ������.</param>
		/// <returns>����� ������.</returns>
		public Order ReRegisterOrder(Order oldOrder, decimal price, decimal volume)
		{
			return Connector.ReRegisterOrder(oldOrder, price, volume);
		}

		/// <summary>
		/// �������� ������ �� �����.
		/// </summary>
		/// <param name="order">������, ������� ����� ��������.</param>
		public void CancelOrder(Order order)
		{
			Connector.CancelOrder(order);
		}

		/// <summary>
		/// �������� ������ ������ �� ����� �� �������.
		/// </summary>
		/// <param name="isStopOrder"><see langword="true"/>, ���� ����� �������� ������ ����-������, false - ���� ������ ������� � null - ���� ��� ����.</param>
		/// <param name="portfolio">��������. ���� �������� ����� null, �� �������� �� �������� � ������ ������ ������.</param>
		/// <param name="direction">����������� ������. ���� �������� ����� null, �� ����������� �� �������� � ������ ������ ������.</param>
		/// <param name="board">�������� ��������. ���� �������� ����� null, �� �������� �� �������� � ������ ������ ������.</param>
		/// <param name="security">����������. ���� �������� ����� null, �� ���������� �� �������� � ������ ������ ������.</param>
		public void CancelOrders(bool? isStopOrder = null, Portfolio portfolio = null, Sides? direction = null, ExchangeBoard board = null, Security security = null)
		{
			Connector.CancelOrders(isStopOrder, portfolio, direction, board, security);
		}

		/// <summary>
		/// ��������� ������� ������ �� �������� ������� � ��������� (��������� ���������, ������������, ������ � �.�.).
		/// </summary>
		public void StartExport()
		{
			Connector.StartExport();
		}

		/// <summary>
		/// ���������� ������� ������ �� �������� ������� � ���������, ���������� ����� <see cref="IConnector.StartExport"/>.
		/// </summary>
		public void StopExport()
		{
			Connector.StopExport();
		}

		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		public event Action<Security, IEnumerable<KeyValuePair<Level1Fields, object>>, DateTimeOffset, DateTime> ValuesChanged;

		private void ValuesChangedHandler(Security security, IEnumerable<KeyValuePair<Level1Fields, object>> changes, DateTimeOffset serverTime, DateTime localTime)
		{
			AddGuiAction(() => ValuesChanged.SafeInvoke(security, changes, serverTime, localTime));
		}

		/// <summary>
		/// �������� �������� ������-������ ��� �����������.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <param name="field">���� ������-������.</param>
		/// <returns>�������� ����. ���� ������ ���, �� ����� ���������� <see langword="null"/>.</returns>
		public object GetSecurityValue(Security security, Level1Fields field)
		{
			return Connector.GetSecurityValue(security, field);
		}

		/// <summary>
		/// �������� ����� ��������� ����� <see cref="Level1Fields"/>, ��� ������� ���� ������-������ ��� �����������.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <returns>����� ��������� �����.</returns>
		public IEnumerable<Level1Fields> GetLevel1Fields(Security security)
		{
			return Connector.GetLevel1Fields(security);
		}

		/// <summary>
		/// ����� �����������, ��������������� ������� <paramref name="criteria"/>.
		/// </summary>
		/// <param name="criteria">����������, ���� �������� ����� �������������� � �������� �������.</param>
		/// <returns>��������� �����������.</returns>
		public IEnumerable<Security> Lookup(Security criteria)
		{
			return Connector.Lookup(criteria);
		}

		/// <summary>
		/// �������� ���������� ������������� �������� �������.
		/// </summary>
		/// <param name="security">����������.</param>
		/// <returns>���������� ������������� �������� �������.</returns>
		public object GetNativeId(Security security)
		{
			return Connector.GetNativeId(security);
		}

		/// <summary>
		/// ���������� ������� �������.
		/// </summary>
		protected override void DisposeManaged()
		{
			Connector.NewSecurities -= NewSecuritiesHandler;
			Connector.SecuritiesChanged -= SecuritiesChangedHandler;
			Connector.NewPortfolios -= NewPortfoliosHandler;
			Connector.PortfoliosChanged -= PortfoliosChangedHandler;
			Connector.NewPositions -= NewPositionsHandler;
			Connector.PositionsChanged -= PositionsChangedHandler;
			Connector.NewTrades -= NewTradesHandler;
			Connector.NewMyTrades -= NewMyTradesHandler;
			Connector.NewOrders -= NewOrdersHandler;
			Connector.OrdersChanged -= OrdersChangedHandler;
			Connector.OrdersRegisterFailed -= OrdersRegisterFailedHandler;
			Connector.OrdersCancelFailed -= OrdersCancelFailedHandler;
			Connector.NewStopOrders -= NewStopOrdersHandler;
			Connector.StopOrdersChanged -= StopOrdersChangedHandler;
			Connector.StopOrdersRegisterFailed -= StopOrdersRegisterFailedHandler;
			Connector.StopOrdersCancelFailed -= StopOrdersCancelFailedHandler;
			Connector.NewMarketDepths -= NewMarketDepthsHandler;
			Connector.MarketDepthsChanged -= MarketDepthsChangedHandler;
			Connector.NewOrderLogItems -= NewOrderLogItemsHandler;
			Connector.NewNews -= NewNewsHandler;
			Connector.NewsChanged -= NewsChangedHandler;
			Connector.Connected -= ConnectedHandler;
			Connector.Disconnected -= DisconnectedHandler;
			Connector.ConnectionError -= ConnectionErrorHandler;
			Connector.ExportStarted -= ExportStartedHandler;
			Connector.ExportStopped -= ExportStoppedHandler;
			Connector.ExportError -= ExportErrorHandler;
			Connector.NewDataExported -= NewDataExportedHandler;
			Connector.ProcessDataError -= ProcessDataErrorHandler;
			Connector.MarketTimeChanged -= MarketTimeChangedHandler;
			Connector.LookupSecuritiesResult -= LookupSecuritiesResultHandler;
			Connector.LookupPortfoliosResult -= LookupPortfoliosResultHandler;
			Connector.MarketDataSubscriptionSucceeded -= MarketDataSubscriptionSucceededHandler;
			Connector.MarketDataSubscriptionFailed -= MarketDataSubscriptionFailedHandler;
			Connector.SessionStateChanged -= SessionStateChangedHandler;
			Connector.ValuesChanged -= ValuesChangedHandler;

			base.DisposeManaged();
		}
	}
}