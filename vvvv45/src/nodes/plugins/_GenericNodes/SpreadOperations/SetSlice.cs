#region usings
using System;
using System.ComponentModel.Composition;
using VVVV.Core.Logging;
using VVVV.Nodes.Generic;
using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

#endregion usings

namespace VVVV.Nodes
{
	
	#region PluginInfo
	[PluginInfo(Name = "SetSlice",
	            Category = "Transform",
	            Help = "Replaces slices in the Spread that are addressed by the Index pin, with the given Input.",
	            Tags = "",
	            Author = "woei")]
	#endregion PluginInfo
	public class SetSliceTransform : SetSlice<Matrix4x4> {}
	
	#region PluginInfo
	[PluginInfo(Name = "SetSlice",
	            Category = "Enumerations",
	            Help = "Replaces slices in the Spread that are addressed by the Index pin, with the given Input.",
	            Tags = "",
	            Author = "woei")]
	#endregion PluginInfo
	public class SetSliceEnum : SetSlice<EnumEntry>
    {
        string FLastSubType;

        protected override void Prepare()
        {
            var outputPin = FOutputContainer.GetPluginIO() as IPin;
            var subType = outputPin.GetDownstreamSubType();
            if (subType != FLastSubType)
            {
                FLastSubType = subType;
                (outputPin as IEnumOut).SetSubType(subType);
                (FSpreadContainer.GetPluginIO() as IEnumIn).SetSubType(subType);
                (FInputContainer.GetPluginIO() as IEnumIn).SetSubType(subType);
            }
        }
    }
	
	#region PluginInfo
	[PluginInfo(Name = "SetSlice",
	            Category = "Raw",
	            Help = "Replaces slices in the Spread that are addressed by the Index pin, with the given Input.",
	            Tags = "",
	            Author = "woei")]
	#endregion PluginInfo
	public class SetSliceRaw : SetSlice<System.IO.Stream> {}
}
