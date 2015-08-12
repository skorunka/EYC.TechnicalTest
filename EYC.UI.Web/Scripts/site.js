$(function () {
	$("form button[data-type='clear']").on("click", function () {
		$(this).closest("form").find(":input").val("");
	});
});