namespace StockSharp.Logging
{
	using System.Collections.Generic;
	using System.Speech.Synthesis;

	using Ecng.Serialization;

	/// <summary>
	/// ������, ������������ ����� ��� ��������� ���������.
	/// </summary>
	public class SpeechLogListener : LogListener
	{
		/// <summary>
		/// ������� <see cref="SpeechLogListener"/>.
		/// </summary>
		public SpeechLogListener()
		{
		}

		/// <summary>
		/// ������� ���������.
		/// </summary>
		public int Volume { get; set; }

		/// <summary>
		/// �������� ���������.
		/// </summary>
		/// <param name="messages">���������� ���������.</param>
		protected override void OnWriteMessages(IEnumerable<LogMessage> messages)
		{
			using (var speech = new SpeechSynthesizer { Volume = Volume })
			{
				foreach (var message in messages)
					speech.Speak(message.Message);
			}
		}

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">��������� ��������.</param>
		public override void Load(SettingsStorage storage)
		{
			base.Load(storage);

			Volume = storage.GetValue<int>("Volume");
		}

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">��������� ��������.</param>
		public override void Save(SettingsStorage storage)
		{
			base.Save(storage);

			storage.SetValue("Volume", Volume);
		}
	}
}