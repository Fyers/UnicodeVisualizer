using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Windows.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(UnicodeVisualizer.UnicodeVisualizer),
typeof(VisualizerObjectSource),
Target = typeof(System.String),
Description = "Unicode Visualizer")]

namespace UnicodeVisualizer
{
    public class UnicodeVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var str = objectProvider.GetObject() as string;

            if (str != null)
            {
                try
                {
                    using (var form = new UnicodeVisualizerForm(str))
                    {
                        form.ShowDialog();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Unicode Visualizer error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(UnicodeVisualizer));
            visualizerHost.ShowVisualizer();
        }
    }
}
