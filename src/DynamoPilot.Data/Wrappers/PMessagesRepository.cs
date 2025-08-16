using Ascon.Pilot.SDK;
using Ascon.Pilot.SDK.Data;
using DynamoPilot.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DynamoPilot.Data.Wrappers
{
    public class PMessagesRepository : IWrapper
    {
        private readonly IMessagesRepository _repository;
        public PMessagesRepository(IMessagesRepository repository)
        {
            _repository = repository;
        }
        public PChat LoadChat(Guid id)
        {
            return new(WaitWithDispatcherFrame(_repository.LoadChatAsync(id)));
        }

        public List<PChatMember> LoadChatMembers(Guid chatId, DateTime dateFromUtc)
        {
            return WaitWithDispatcherFrame(_repository.LoadChatMembersAsync(chatId, dateFromUtc)).Select(i => new PChatMember(i)).ToList();
        }

        public IReadOnlyList<IChatMessage> LoadMessages(Guid chatId, DateTime dateFromUtc, DateTime dateToUtc, int maxNumber)
        {
            return WaitWithDispatcherFrame(_repository.LoadMessagesAsync(chatId, dateFromUtc, dateToUtc, maxNumber));
        }

        public bool SendMessage(IChatMessage message)
        {
            WaitWithDispatcherFrame(_repository.SendMessageAsync(message));
            return true;
        }

        public object Unwrap()
        {
            return _repository;
        }

        private static T WaitWithDispatcherFrame<T>(Task<T> task)
        {
            if (task.IsCompleted)
                return task.GetAwaiter().GetResult();

            var syncContext = SynchronizationContext.Current;
            if (syncContext is DispatcherSynchronizationContext)
            {
                var frame = new DispatcherFrame();
                task.ContinueWith(_ => frame.Continue = false, TaskScheduler.FromCurrentSynchronizationContext());
                Dispatcher.PushFrame(frame);
                return task.GetAwaiter().GetResult();
            }

            return task.GetAwaiter().GetResult();
        }

        private static void WaitWithDispatcherFrame(Task task)
        {
            if (task.IsCompleted)
            {
                task.GetAwaiter().GetResult();
                return;
            }

            var syncContext = SynchronizationContext.Current;
            if (syncContext is DispatcherSynchronizationContext)
            {
                var frame = new DispatcherFrame();
                task.ContinueWith(_ => frame.Continue = false, TaskScheduler.FromCurrentSynchronizationContext());
                Dispatcher.PushFrame(frame);
                task.GetAwaiter().GetResult();
                return;
            }

            task.GetAwaiter().GetResult();
        }
    }
}
