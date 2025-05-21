using System.Drawing;

namespace SAM.Core.Windows
{
    public static partial class Query
    {
        public static Bitmap Bitmap(this LogRecordType logRecordType)
        {
            switch (logRecordType)
            {
                case LogRecordType.Error:
                    return Properties.Resources.SAM_Error;

                case LogRecordType.Warning:
                    return Properties.Resources.SAM_Warning;

                case LogRecordType.Message:
                    return Properties.Resources.SAM_Information;

            }

            return null;
        }
    }
}