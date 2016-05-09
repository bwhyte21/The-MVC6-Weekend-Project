$(function () {
    /* Clock functionality */
    function GetClock() {
        var d = new Date();
        var nmonth = d.getMonth(), ndate = d.getDate(), nyear = d.getYear();
        if (nyear < 1000) nyear += 1900;
        var nhour = d.getHours(), nmin = d.getMinutes();
        if (nmin <= 9) nmin = "0" + nmin

        document.getElementById('clockbox').innerHTML = "" + (nmonth + 1) + "/" + ndate + "/" + nyear + " " + nhour + ":" + nmin + "";
    }
    window.onload = function () {
        GetClock();
        setInterval(GetClock, 1000);
    }

    /* For delete click */
    $("a.delete-link").click(function () {
        //Hide the delete button once clicked
        var deleteLink = $(this);
        deleteLink.hide();
        //then show the confirm button
        var confirmButton = deleteLink.siblings(".delete-confirm");
        confirmButton.show();

        //cancel if necessary
        var fnCancelDelete = function () {
            fnRemoveEvents();
            fnShowDeleteLink();
        };

        //delete the item once confirmed
        var fnDeleteItem = function () {
            fnRemoveEvents();
            confirmButton.hide();
            //Make an AJAX post
            var url = 'Movies/Delete/?' + 'id=' + confirmButton.attr('data-delete-id');
            $.ajax({
                 url: url,
                 type: 'GET',
                 cache: false,
                 success: function (result) {
                     var parentRow = deleteLink.parents("tr:first");
                     parentRow.fadeOut('fast', function () {
                         parentRow.remove();
                     });
                 },
                 error: function (result) {
                     alert("Error with ajax request!");
                 }
            });
            /*$.post(
                '@Url.Action("Delete")',
                AddAntiForgeryToken({ id: confirmButton.attr('data-delete-id') }))
            .done(function () {
                var parentRow = deleteLink.parents("tr:first");
                parentRow.fadeOut('fast', function () {
                    parentRow.remove();
                });
            })
            .fail(function (data) {

                alert(JSON.stringify(data));
            });*/
            return false;
        };

        //remove events upon cancellation or otherwise
        var fnRemoveEvents = function () {
            confirmButton.off("click", fnDeleteItem);
            $(document).on("click", fnCancelDelete);
            $(document).off("keypress", fnOnKeyPress);
        };

        //show delete button once more after an action was taken
        var fnShowDeleteLink = function () {
            confirmButton.hide();
            deleteLink.show();
        };

        //escape confirm window on keypress, case the user changes their mind
        var fnOnKeyPress = function (e) {
            //Cancel if escape key pressed
            if (e.which == 27) { fnCancelDelete(); }
        };

        confirmButton.on("click", fnDeleteItem);
        $(document).on("click", fnCancelDelete);
        $(document).on("keypress", fnOnKeyPress);

        return false;
    });
    AddAntiForgeryToken = function (data) {
        data.__RequestVerificationToken = $('input[name=__RequestVerificationToken]').val();
        return data;
    };
});