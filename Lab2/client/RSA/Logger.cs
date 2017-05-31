using System;
using System.Windows.Forms;

    class Logger
    {
        private static RichTextBox initializedRBox;
    private delegate void addFunction(string input, bool data);
        private static addFunction addingFunction;
        public static void Log(string input, bool withData = true)
        {

            try
            {
                initializedRBox.Invoke(addingFunction, input, withData);
            }
            catch { }

        }
    public static void Init(RichTextBox rb)
        {
            initializedRBox = rb;

            addingFunction = delegate(string input, bool withDate) { 
                if (initializedRBox.Lines.Length > 100) {
                    initializedRBox.Clear();
                }
                initializedRBox.AppendText("\n" + (withDate ? String.Format("[{0:d.M.yyyy, HH:mm:ss}] ", DateTime.Now) : string.Empty) +  input);
            };

        }

    }


