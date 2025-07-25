using ModSettings;

namespace FortifiedLookouts
{
    internal class FortifiedLookouts : JsonModSettings
    {

        [Name("Mystery Lake - Lookout")]
        [Description("Enable Larger Lookout")]
        public bool mysteryLookout = false;

        [Name("     Mystery Lake - Second Lookout Tower")]
        [Description("Enable Second Regular Sized Lookout")]
        public bool mysteryMini = false;

        [Name("     Mystery Lake - Lookout Windows")]
        [Description("Raise the Windows")]
        public bool mysteryWindows = false;



        [Name("Bleak Inlet - Lookout")]
        [Description("Enable Larger Lookout")]
        public bool bleakLookout = false;

        [Name("     Bleak Inlet - Second Lookout Tower")]
        [Description("Enable Second Regular Sized Lookout")]
        public bool bleakMini = false;

        [Name("     Bleak Inlet - Lookout Windows")]
        [Description("Raise the Windows")]
        public bool bleakWindows = false;

        

        [Name("Coastal Highway - Lookout")]
        [Description("Enable Larger Lookout")]
        public bool coastalLookout = false;

        [Name("     Coastal Highway - Second Lookout Tower")]
        [Description("Enable Second Regular Sized Lookout")]
        public bool coastalMini = false;

        [Name("     Coastal Highway - Lookout Windows")]
        [Description("Raise the Windows")]
        public bool coastalWindows = false;

    }

    internal static class Settings
    {
        public static FortifiedLookouts options;

        public static void OnLoad()
        {
            options = new FortifiedLookouts();
            options.AddToModSettings("Fortified Lookouts", MenuType.Both);
        }
    }

}