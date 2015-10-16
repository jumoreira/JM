using System;
using System.IO;
using System.Web.Mvc;

namespace JM.Web.MVC.Util.Blocks
{
    public class BootstrapPanel : IDisposable
    {
        private bool _disposed;
        private readonly FormContext _originalFormContext;
        private readonly ViewContext _viewContext;
        private readonly TextWriter _writer;

        public BootstrapPanel(ViewContext viewContext, string title)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }
            _viewContext = viewContext;
            _writer = viewContext.Writer;
            _originalFormContext = viewContext.FormContext;
            viewContext.FormContext = new FormContext();

            Begin(title);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Begin(string title)
        {
            _writer.Write(String.Format(
            @"
            <div class='panel panel-primary'>
                <div class='panel-heading'>
                    <h3 class='panel-title'>
                        {0}
                    </h3>
                </div>
            ", title));
        }
        private void End()
        {
            _writer.Write("</div>");
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                End();

                if (_viewContext != null)
                {
                    _viewContext.OutputClientValidation();
                    _viewContext.FormContext = _originalFormContext;
                }
            }
        }
        public override string ToString()
        {
            Dispose();
            return _writer.ToString();
        }
    }
}
