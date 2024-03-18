using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dicery.BaseModules
{
    public class DisposableBase: IDisposable
    {
        private bool _disposedValue;
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }
}
