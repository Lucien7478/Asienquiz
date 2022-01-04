using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Asienquiz.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Asienquiz.Properties.Resources.resourceMan == null)
          Asienquiz.Properties.Resources.resourceMan = new ResourceManager("Asienquiz.Properties.Resources", typeof (Asienquiz.Properties.Resources).Assembly);
        return Asienquiz.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Asienquiz.Properties.Resources.resourceCulture;
      }
      set
      {
        Asienquiz.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap Asien_Karte
    {
      get
      {
        return (Bitmap) Asienquiz.Properties.Resources.ResourceManager.GetObject("Asien-Karte", Asienquiz.Properties.Resources.resourceCulture);
      }
    }
  }
}
