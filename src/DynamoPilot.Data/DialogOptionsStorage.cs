using Ascon.Pilot.SDK;
using DynamoPilot.Data.Wrappers;
using System;
using System.Collections.Concurrent;

namespace DynamoPilot.Data
{
    /// <summary>
    /// Глобальное сторедж-хранилище опций диалогов по GUID ноды.
    /// Хранит как есть (object) во избежание проблем идентичности типов между контекстами загрузки.
    /// </summary>
    public static class DialogOptionsStorage
    {
        private static readonly ConcurrentDictionary<Guid, object> NodeIdToOptions = new();

        public static object Capture(string nodeId, object options)
        {
            if (!Guid.TryParse(nodeId, out var guid))
                return options;

            if (options == null)
            {
                NodeIdToOptions.TryRemove(guid, out _);
                return null;
            }

            NodeIdToOptions[guid] = options;
            return options;
        }

        public static PPilotDialogOptions Get(string nodeId)
        {
            if (!Guid.TryParse(nodeId, out var guid))
                return null;

            if (!NodeIdToOptions.TryGetValue(guid, out var stored) || stored == null)
                return null;

            // Fast path
            if (stored is PPilotDialogOptions popts)
                return popts;

            try
            {
                var unwrapMethod = stored.GetType().GetMethod("Unwrap");
                if (unwrapMethod != null)
                {
                    var unwrapped = unwrapMethod.Invoke(stored, null);
                    if (unwrapped is IPilotDialogOptions sdkOptions)
                    {
                        return new PPilotDialogOptions(sdkOptions);
                    }
                }
            }
            catch
            {
                // ignore
            }

            return null;
        }
    }
}


