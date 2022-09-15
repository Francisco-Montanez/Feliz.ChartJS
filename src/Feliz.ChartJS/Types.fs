namespace Feliz.ChartJS

open Fable.Core

/// This interface allows us to stop adding random props to the react chart js.
type IChartJSProp =
    interface
    end

type IOptionsProp =
    interface
    end
type IPluginsProp =
    interface
    end
type IScalesProp =
    interface
    end
type IAxesProp =
    interface
    end

type ILegendProp =
    interface
    end
type ITitleProp =
    interface
    end
type IDataLabelsProp =
    interface
    end
type ILabelsProp =
    interface
    end
type IDataLabelProp =
    interface
    end
type IFontProp =
    interface
    end

type ILineChartProp =
    interface
    end
type IBarChartProp =
    interface
    end
type IDoughnutChartProp =
    interface
    end

type ILineDataProp =
    interface
    end

type ILineDataSetsProp =
    interface
    end
type IBarDataProp =
    interface
    end

type IBarDataSetsProp =
    interface
    end
type IDoughnutDataProp =
    interface
    end

type IDoughnutDataSetsProp =
    interface
    end

[<Erase>]
type IContextProperties =
    abstract cy : float
    abstract cx : float
    abstract midAngle : float
    abstract innerRadius : float
    abstract outerRadius : float
    abstract percent : float
    abstract index : int