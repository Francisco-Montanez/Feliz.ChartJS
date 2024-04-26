module Index

open System
open Elmish
open Feliz
open Feliz.ChartJS
open Browser.Dom
open Fable.Core.JsInterop
open Browser.Types
open PluginsCallbacks

type Model = { Txt: string }

type Msg = UpdateTxt of string

let init () = { Txt = "" }, Cmd.none

let update msg (model: Model) =
    match msg with
    | UpdateTxt txt -> { model with Txt = txt }, Cmd.none

[<ReactComponent>]
let ChartJSLineChart () =
    ChartJS.line [
        line.options [
            option.responsive true
            option.scales [
                scale.yWithAxes [
                    axes.ticks [
                        ticks.color "red"
                    ]
                    axes.position Position.Left
                    axes.title [ title.display true; title.text "test" ]
                ]
                scale.xWithAxes [
                    axes.ticks [
                        ticks.color "green"
                    ]
                ]
                scale.yRight [ axes.position Position.Right; axes.reverse true ]
            ]

            option.plugins[plugin.datalabels [
                               datalabels.display true
                               datalabels.align Position.Bottom
                               datalabels.borderRadius 3
                               datalabels.color "red"
                               datalabels.backgroundColor "green"
                           ]

                           plugin.zoom [ zoom.wheel [ wheel.enabled true ] ]]
        ]
        line.data [
            lineData.labels [| "Red"; "Blue"; "Yellow"; "Green"; "Purple"; "Orange" |]
            lineData.datasets [|
                lineData.dataset [
                    lineDataSet.label "My First Dataset"
                    lineDataSet.borderColor "rgb(53, 162, 235)"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [| "1"; "2"; "3"; "4"; "312"; "6" |]
                ]
                lineData.dataset [
                    lineDataSet.label "My Second Dataset"
                    lineDataSet.borderColor "yellow"
                    lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
                    lineDataSet.data [| "1"; "2"; "3"; "4"; "4"; "1500" |]
                    lineDataSet.yAxisID "yRight"
                ]
            |]
        ]
    ]

// [<ReactComponent>]
// let ChartJSLineChartWithCustomToolTips () =
//     ChartJS.line [
//         line.options [
//             option.responsive true
//             option.scales [
//                 scale.y [
//                     axes.position Position.Left
//                     axes.title [ title.display true; title.text "test" ]
//                 ]
//                 scale.yRight [ axes.position Position.Right; axes.reverse true ]
//             ]

//             option.plugins[plugin.datalabels [
//                                datalabels.display true
//                                datalabels.align Position.Bottom
//                                datalabels.borderRadius 3
//                                datalabels.color "red"
//                                datalabels.backgroundColor "green"
//                            ]

//                            plugin.tooltip [
//                                tooltip.borderColor "red"
//                                tooltip.caretSize 15
//                                tooltip.backgroundColor "pink"
//                                tooltip.titleColor "green"
//                                tooltip.bodyColor "yellow"
//                                tooltip.callbacks [
//                                    tooltipcallback.beforeTitle (fun items ->
//                                        console.log items
//                                        items |> Array.map (fun item -> "BeforeTitle" + item.label))
//                                    tooltipcallback.title (fun items ->
//                                        items |> Array.map (fun item -> "Title" + item.label))
//                                ]
//                                tooltip.position ToolTipPosition.Nearest
//                            ]

//                            plugin.zoom [ zoom.wheel [ wheel.enabled true ] ]]
//         ]
//         line.data [
//             lineData.labels [| "Red"; "Blue"; "Yellow"; "Green"; "Purple"; "Orange" |]
//             lineData.datasets [|
//                 lineData.dataset [
//                     lineDataSet.label "My First Dataset"
//                     lineDataSet.borderColor "rgb(53, 162, 235)"
//                     lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     lineDataSet.data [| "1"; "2"; "3"; "4"; "312"; "6" |]
//                 ]
//                 lineData.dataset [
//                     lineDataSet.label "My Second Dataset"
//                     lineDataSet.borderColor "yellow"
//                     lineDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     lineDataSet.data [| "1"; "2"; "3"; "4"; "4"; "1500" |]
//                     lineDataSet.yAxisID "yRight"
//                 ]
//             |]
//         ]
//     ]

// [<ReactComponent>]
// let ChartJSBarChart () =
//     ChartJS.bar [
//         // bar.register()
//         bar.options [
//             option.responsive true
//             option.scales [ scale.x [ axes.stacked true ]; scale.y [ axes.stacked true ] ]
//             option.plugins [
//                 plugin.legend [ legend.position Position.Top ]
//                 plugin.title [ title.display true; title.text "Chart.js Bar Chart" ]
//                 plugin.datalabels [
//                     datalabels.display true
//                     datalabels.alignn Position.Bottom
//                     datalabels.borderRadius 3
//                     datalabels.color "red"
//                     datalabels.backgroundColor "green"
//                 // datalabels.labels [
//                 //     labels.value {|color="blue"|}
//                 // ]
//                 // datalabels.formatter renderCustomLabel
//                 ]
//             ]
//         ]
//         bar.data [
//             barData.labels [| "January"; "Feburary" |]
//             barData.datasets [|
//                 barData.dataset [
//                     barDataSet.label "My First Dataset"
//                     barDataSet.borderColor "blue"
//                     barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     barDataSet.borderSkipped false
//                     barDataSet.borderWidth 2
//                     barDataSet.borderRadius 50
//                     barDataSet.data [| "1"; "2" |]
//                 ]
//                 barData.dataset [
//                     barDataSet.label "My Second Dataset"
//                     barDataSet.borderColor "green"
//                     barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     barDataSet.borderSkipped false
//                     barDataSet.borderWidth 2
//                     barDataSet.borderRadius 50
//                     barDataSet.data [| "1"; "2" |]
//                 ]
//             |]
//         ]
//     ]

// let renderCustomLabel (context: IContextProperties) =

//     Svg.text [ svg.text "test" ]

[<ReactComponent>]
let ChartJSDoughnutChart () =
    let chartRef: IRefValue<Interop.ChartJS option> = React.useRef (None)

    let receiveChartRef () =
        match chartRef.current with
        | None -> failwithf "should be some"
        | Some e -> e

    let counter =
        inlineplugin.plugin [
            inlineplugins.id "counter"
            inlineplugins.beforeDraw (fun handler ->
                handler.ctx.save
                handler.ctx.fillStyle <- "pink"
                handler.ctx.font <- "60px Arial"
                handler.ctx.textAlign <- "center"
                handler.ctx.textAlign <- "center"
                handler.ctx.textAlign <- "center"
                handler.ctx.fillText ("97", 100, 100)
                console.log handler.ctx)
        ]

    ChartJS.doughnut [
        doughnut.ref chartRef
        doughnut.plugins [ counter ]
        doughnut.onClick (fun (e) ->
            let ref = receiveChartRef ()
            console.log ref
            console.log e
            let dataSet = Interop.eventOperations.getDatasetAtEvent (ref, e)
            console.log dataSet)
        doughnut.options [
            option.responsive true
            option.layout [ layout.padding [ padding.bottom 10 ] ]
            option.plugins [
                plugin.legend [ legend.position Position.Top ]
                plugin.title [ title.display true; title.text "Chart.js Doughnut Chart" ]
                plugin.datalabels [
                    datalabels.display true
                    datalabels.align Position.Bottom
                    datalabels.borderRadius 3
                    datalabels.color "red"
                    datalabels.backgroundColor "green"
                // datalabels.labels [
                //     labels.value {|color="blue"|}
                // ]
                // datalabels.formatter renderCustomLabel
                ]
            ]
        ]
        doughnut.data [
            doughnutData.labels [| "Red"; "Blue"; "Yellow"; "Green"; "Purple"; "Orange" |]
            doughnutData.datasets [|
                doughnutData.dataset [
                    doughnutDataSet.label "# of Votes"
                    doughnutDataSet.borderColor [|
                        "rgba(255, 99, 132, 1)"
                        "rgba(54, 162, 235, 1)"
                        "rgba(255, 206, 86, 1)"
                        "rgba(75, 192, 192, 1)"
                        "rgba(153, 102, 255, 1)"
                        "rgba(255, 159, 64, 1)"
                    |]
                    doughnutDataSet.borderWidth 1
                    doughnutDataSet.hoverOffset 20
                    doughnutDataSet.backgroundColor [|
                        "rgba(255, 99, 132, 0.2)"
                        "rgba(54, 162, 235, 0.2)"
                        "rgba(255, 206, 86, 0.2)"
                        "rgba(75, 192, 192, 0.2)"
                        "rgba(153, 102, 255, 0.2)"
                        "rgba(255, 159, 64, 0.2)"
                    |]
                    doughnutDataSet.data [| 12; 19; 3; 5; 2; 3 |]
                    doughnutDataSet.datalabels [| datalabel.anchor "end" |]
                ]
            |]
        ]
    ]

[<ReactComponent>]
let ChartJSMultiDoughnutChart () =
    let chartRef: IRefValue<Interop.ChartJS option> = React.useRef (None)

    let receiveChartRef () =
        match chartRef.current with
        | None -> failwithf "should be some"
        | Some e -> e

    let counter =
        inlineplugin.plugin [
            inlineplugins.id "counter"
            inlineplugins.beforeDraw (fun handler ->
                handler.ctx.save
                handler.ctx.fillStyle <- "pink"
                handler.ctx.font <- "60px Arial"
                handler.ctx.textAlign <- "center"
                handler.ctx.textAlign <- "center"
                handler.ctx.textAlign <- "center"
                handler.ctx.fillText ("97", 100, 100)
                console.log handler.ctx)
        ]

    ChartJS.doughnut [
        doughnut.ref chartRef
        doughnut.plugins [ counter ]
        doughnut.onClick (fun (e) ->
            let ref = receiveChartRef ()
            console.log ref
            console.log e
            let dataSet = Interop.eventOperations.getDatasetAtEvent (ref, e)
            console.log dataSet)
        doughnut.options [
            option.responsive true
            option.layout [ layout.padding [ padding.bottom 10 ] ]
            option.plugins [
                plugin.legend [ legend.position Position.Top ]
                plugin.title [ title.display true; title.text "Chart.js Doughnut Chart" ]
                plugin.datalabels [
                    datalabels.display true
                    datalabels.align Position.Bottom
                    datalabels.borderRadius 3
                    datalabels.color "red"
                    datalabels.backgroundColor "green"
                // datalabels.labels [
                //     labels.value {|color="blue"|}
                // ]
                // datalabels.formatter renderCustomLabel
                ]
            ]
        ]
        doughnut.data [
            doughnutData.labels [| "Red"; "Blue"; "Yellow"; "Green"; "Purple"; "Orange" |]
            doughnutData.datasets [|
                doughnutData.dataset [
                    doughnutDataSet.label "# of Votes"
                    doughnutDataSet.borderColor [|
                        "rgba(255, 99, 132, 1)"
                        "rgba(54, 162, 235, 1)"
                        "rgba(255, 206, 86, 1)"
                        "rgba(75, 192, 192, 1)"
                        "rgba(153, 102, 255, 1)"
                        "rgba(255, 159, 64, 1)"
                    |]
                    doughnutDataSet.borderWidth 1
                    doughnutDataSet.hoverOffset 20
                    doughnutDataSet.backgroundColor [|
                        "rgba(255, 99, 132, 0.2)"
                        "rgba(54, 162, 235, 0.2)"
                        "rgba(255, 206, 86, 0.2)"
                        "rgba(75, 192, 192, 0.2)"
                        "rgba(153, 102, 255, 0.2)"
                        "rgba(255, 159, 64, 0.2)"
                    |]
                    doughnutDataSet.data [| 12; 19; 3; 5; 2; 3 |]
                    doughnutDataSet.datalabels [| datalabel.anchor "end" |]
                ]
                doughnutData.dataset [
                    doughnutDataSet.label "Detailed of Votes"
                    doughnutDataSet.borderColor [|
                        "rgba(255, 99, 132, 1)"
                        "rgba(54, 162, 235, 1)"
                        "rgba(255, 206, 86, 1)"
                        "rgba(75, 192, 192, 1)"
                        "rgba(153, 102, 255, 1)"
                        "rgba(255, 159, 64, 1)"
                    |]
                    doughnutDataSet.borderWidth 1
                    doughnutDataSet.hoverOffset 20
                    doughnutDataSet.backgroundColor [|
                        "rgba(255, 99, 132, 0.2)"
                        "rgba(54, 162, 235, 0.2)"
                        "rgba(255, 206, 86, 0.2)"
                        "rgba(75, 192, 192, 0.2)"
                        "rgba(153, 102, 255, 0.2)"
                        "rgba(255, 159, 64, 0.2)"
                    |]
                    doughnutDataSet.data [| 12; 19; 3; 5; 2; 3 |]
                    doughnutDataSet.datalabels [| datalabel.anchor "end" |]
                ]
            |]
        ]
    ]

// [<ReactComponent>]
// let ChartJSMixedTypeChart () =
//     ChartJS.bar [
//         // bar.register()
//         bar.options [
//             option.responsive true
//             option.scales [ scale.x [ axes.stacked true ]; scale.y [ axes.stacked true ] ]
//             option.plugins [
//                 plugin.legend [ legend.position Position.Top ]
//                 plugin.title [ title.display true; title.text "Chart.js Bar Chart" ]
//                 plugin.datalabels [
//                     datalabels.display true
//                     datalabels.alignn Position.Bottom
//                     datalabels.borderRadius 3
//                     datalabels.color "red"
//                     datalabels.backgroundColor "green"
//                 // datalabels.labels [
//                 //     labels.value {|color="blue"|}
//                 // ]
//                 // datalabels.formatter renderCustomLabel
//                 ]
//             ]
//         ]
//         bar.data [
//             barData.labels [| "January"; "Feburary" |]
//             barData.datasets [|
//                 barData.dataset [
//                     barDataSet.label "My First Dataset"
//                     barDataSet.borderColor "blue"
//                     barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     barDataSet.borderSkipped false
//                     barDataSet.borderWidth 2
//                     barDataSet.borderRadius 50
//                     barDataSet.data [| "1"; "2" |]
//                 ]
//                 barData.dataset [
//                     barDataSet.label "My Second Dataset"
//                     barDataSet.mixedType "line"
//                     barDataSet.borderColor "green"
//                     barDataSet.backgroundColor "rgba(53, 162, 235, 0.5)"
//                     barDataSet.borderSkipped false
//                     barDataSet.borderWidth 2
//                     barDataSet.borderRadius 50
//                     barDataSet.data [| "1"; "2" |]
//                 ]
//             |]
//         ]
//     ]

let view (model: Model) (dispatch: Msg -> unit) =
    Html.div [
        prop.style [ style.height 600; style.width 600 ]
        prop.children [
            // ChartJSLineChart()
        // ChartJSLineChartWithCustomToolTips()
        // ChartJSBarChart()
        // ChartJSDoughnutChart()
            ChartJSMultiDoughnutChart()
        // ChartJSMixedTypeChart()
        ]

    ]
