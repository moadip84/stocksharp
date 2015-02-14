namespace StockSharp.Messages
{
	using System;
	using System.Linq;
	using System.Threading;

	using Ecng.Collections;
	using Ecng.Common;

	/// <summary>
	/// ��� ������������ ���������.
	/// </summary>
	public class MessageProcessorPool : IMessageProcessor
	{
		private readonly SynchronizedDictionary<MessageTypes, IMessageProcessor> _innerDict = new SynchronizedDictionary<MessageTypes, IMessageProcessor>();
		private readonly IMessageProcessor[] _allProcessors;
		private int _activeProcessors;

		/// <summary>
		/// ������� <see cref="MessageProcessorPool"/>.
		/// </summary>
		/// <param name="defaultProcessor">���������� ��������� ��-���������.</param>
		public MessageProcessorPool(IMessageProcessor defaultProcessor)
		{
			if (defaultProcessor == null)
				throw new ArgumentNullException("defaultProcessor");

			DefaultProcessor = defaultProcessor;
			StartProcessor(DefaultProcessor);

			var types = Enumerator.GetValues<MessageTypes>().Cast<int>().ToArray();

			_allProcessors = new IMessageProcessor[types.Length];

			foreach (var type in types)
				_allProcessors[type] = DefaultProcessor;
		}

		bool IMessageProcessor.IsStarted
		{
			get { return DefaultProcessor.IsStarted; }
		}

		int IMessageProcessor.MessageCount
		{
			get { return DefaultProcessor.MessageCount; }
		}

		int IMessageProcessor.MaxMessageCount
		{
			get { return DefaultProcessor.MaxMessageCount; }
			set { DefaultProcessor.MaxMessageCount = value; }
		}

		/// <summary>
		/// ���������� ��������� ��-���������.
		/// </summary>
		public IMessageProcessor DefaultProcessor { get; private set; }
		
		/// <summary>
		/// ������� ��������� ������ ���������.
		/// </summary>
		public event Action<Message, IMessageAdapter> NewMessage;

		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		public event Action Stopped;

		void IMessageProcessor.Start()
		{
		}

		void IMessageProcessor.Stop()
		{
			Clear();
			DefaultProcessor.Stop();
		}

		void IMessageProcessor.Clear(ClearMessageQueueMessage message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			DefaultProcessor.Clear(message);
		}

		private void StartProcessor(IMessageProcessor processor)
		{
			if (processor == null)
				throw new ArgumentNullException("processor");

			processor.NewMessage += (m, a) => NewMessage.SafeInvoke(m, a);
			processor.Stopped += () =>
			{
				if (Interlocked.Decrement(ref _activeProcessors) == 0)
					Stopped.SafeInvoke();
			};
			Interlocked.Increment(ref _activeProcessors);
			processor.Start();
		}

		/// <summary>
		/// �������� ���������� ���� ������������.
		/// </summary>
		public int Count
		{
			get { return _innerDict.Count; }
		}

		void IMessageProcessor.EnqueueMessage(Message message, IMessageAdapter adapter, bool force)
		{
			this[message.Type].EnqueueMessage(message, adapter, force);
		}

		/// <summary>
		/// �������� ��� ���������� ���������� �� ���� ���������.
		/// </summary>
		/// <param name="type">��� ���������.</param>
		/// <returns>����������.</returns>
		public IMessageProcessor this[MessageTypes type]
		{
			get
			{
				var index = (int)type;
				return index >= 0 && index < _allProcessors.Length ? _allProcessors[index] : DefaultProcessor;
			}
			set
			{
				lock (_innerDict.SyncRoot)
				{
					if (_innerDict.ContainsKey(type))
					{
						if (_innerDict[type] == value)
							return;

						Remove(type);
					}

					Add(type, value);
				}
			}
		}

		/// <summary>
		/// �������� ����������.
		/// </summary>
		/// <param name="type">��� ���������.</param>
		/// <param name="processor">����������.</param>
		public void Add(MessageTypes type, IMessageProcessor processor)
		{
			var index = (int)type;

			if (index < 0 || index >= _allProcessors.Length)
				throw new ArgumentOutOfRangeException("type");

			lock (_innerDict.SyncRoot)
			{
				_innerDict.Add(type, processor);
				_allProcessors[index] = processor;
			}

			if (!processor.IsStarted)
				StartProcessor(processor);
		}

		/// <summary>
		/// ������� ���������� ���������.
		/// </summary>
		/// <param name="type">��� ���������.</param>
		/// <returns><see langword="true"/>, ���� ���������� ��� ������ � ������. �����, <see langword="false"/>.</returns>
		public bool Remove(MessageTypes type)
		{
			var index = (int)type;

			if (index < 0 || index >= _allProcessors.Length)
				throw new ArgumentOutOfRangeException("type");

			IMessageProcessor processor = null;

			try
			{
				lock (_innerDict.SyncRoot)
				{
					processor = _allProcessors[index];
					_allProcessors[index] = DefaultProcessor;

					if (_allProcessors.Contains(processor))
						processor = null;

					return _innerDict.Remove(type);
				}
			}
			finally
			{
				if (processor != null)
					processor.Stop();
			}
		}

		/// <summary>
		/// ������� ��� �����������.
		/// </summary>
		public void Clear()
		{
			foreach (var processor in _allProcessors)
			{
				if (processor != null && processor != DefaultProcessor)
					processor.Stop();
			}

			for (var i = 0; i < _allProcessors.Length; i++)
				_allProcessors[i] = DefaultProcessor;

			lock (_innerDict.SyncRoot)
				_innerDict.Clear();
		}
	}
}