/*$("#AlleKampeID").on("click", "input", function () {
    var theForm = $("#AlleKampeID form");
    theForm.preventDefault();
    console.log("fisk");
    theForm.attr("action", "/KuponController/Odds1");
    //theForm.submit();
});*/
$("#AlleKampeID form").submit(function(e) {
    e.preventDefault();
    console.log("fisk");
    $(this).attr("action", "/KuponController/Odds1");
});
/*
$(".Odds1").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("Odds1", "KuponController")");
    theForm.submit();
});
$(".OddsX").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("OddsX", "KuponController")");
    theForm.submit();
});
$(".Odds2").click(function () {
    var theForm = $(".kampForm");
    theForm.preventDefault();
    theForm.attr("action", "@Url.Action("Odds2", "KuponController")");
    theForm.submit();
});*/