document.addEventListener("DOMContentLoaded", function () {
    $(".top-menu li a").click(function () {
        $(".top-menu li").find("a").removeClass("top-menu-active");
        $(this).addClass("top-menu-active");
    });
    $(".navigation-menu > ul > li").click(function () {
        if ($(this).find("a").first().hasClass("click-remove")) {
            var level = $(this).find(".smenu").attr("menu-level");
            $(this).find(".smenu").removeClass(level)
            $(this).find("a").first().removeClass("click-remove");
        }
        else {
            var level = $(this).find(".smenu").attr("menu-level");
            $(this).find(".smenu").addClass(level)
            $(this).find("a").first().addClass("click-remove");
        }

    });
    $(".user-dtl").click(function () {
        $(this).toggleClass("right-menu-active");
        $(".top-sub-menu").toggleClass("show");
    });
    //$("select").SumoSelect({ search: true, searchText: 'Enter here.' });
})
function InlineLoading(evt, action) {
    if (action == "Show") {
        $(evt).find("span").removeClass("hide");
        $(evt).find("span").addClass("show");
        $(evt).find("span>svg").addClass("fa-spin");
        $(evt).attr("disabled", "disabled");
    }
    else {
        $(evt).find("span").removeClass("show");
        $(evt).find("span").addClass("hide");
        $(evt).find("svg").removeClass("fa-spin");
        $(evt).removeAttr("disabled");
    }
}