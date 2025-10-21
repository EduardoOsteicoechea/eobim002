using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading;

namespace Eduardoos.RevitApi
{
	public sealed class EventAggregator
	{
		private static readonly EventAggregator _instance = new EventAggregator();
		public static EventAggregator Instance = _instance;

		private readonly Dictionary<Type, List<object>> _subscriptions = new Dictionary<Type, List<object>>();
		private readonly object _lock = new object();

		private EventAggregator() { }

		public void Subscribe<TMessage>(Action<TMessage> handler)
		{
			Type messageType = typeof(TMessage);

			lock (_lock)
			{
				if (!_subscriptions.ContainsKey(messageType))
				{
					_subscriptions[messageType] = new List<object>();
				}
				_subscriptions[messageType].Add(handler);
			}
		}

		public void Publish<TMessage>(TMessage message)
		{
			Type messageType = typeof(TMessage);
			List<object> handlers;

			lock (_lock)
			{
				if (!_subscriptions.ContainsKey(messageType))
				{
					return; // No one is listening, do nothing
				}

				handlers = _subscriptions[messageType].ToList();
			}

			foreach (var handler in handlers)
			{
				if (handler is Action<TMessage> typedHandler)
				{
					// The subscriber is now responsible for marshalling to the UI thread if needed.
					typedHandler(message);
				}
			}

			//foreach (var handler in handlers)
			//{
			//	if (handler is Action<TMessage> typedHandler)
			//	{
			//		// Run the handler on the UI thread to prevent cross-thread exceptions
			//		// in WPF/WinForms applications.
			//		App.Current?.Dispatcher.Invoke(() => typedHandler(message));
			//	}
			//}
		}

		public void Unsubscribe<TMessage>(Action<TMessage> handler)
		{
			Type messageType = typeof(TMessage);

			lock (_lock)
			{
				if (_subscriptions.ContainsKey(messageType))
				{
					_subscriptions[messageType].Remove(handler);
				}
			}
		}



	}
}