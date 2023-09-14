var PageNumber = 1;
$(document).ready(function () {
    // Add selected item to the to-do list
    $("#addItemButton").click(function () {
        var task = $("#itemDropdown").val();
        if (task != null) {
            const dropdown = document.getElementById("itemDropdown");
            const selectedOption = dropdown.querySelector("option[value='" + task + "']");
            if (selectedOption) {
                selectedOption.disabled = true;
            }
            if (task === "has photo on profile") {
                if (task !== "") {
                    var newRow = $("<tr><td><button class='btn btn-danger fa fa-close closeButton'></button></td><td>" + task + "</td><td class='text-right'><input type='radio' value='true'/> Yes <input type='radio' value='false'/> No </td></tr>");
                    $("#todoList tbody").append(newRow);
                    $("#itemDropdown").val("");
                    newRow.find("input").attr("name", "HasPhoto");
                }
            }
            else if (task === "has created a account within __ days" || task === "has not created a account within __ days") {
                var newRow = $("<tr><td><button class='btn btn-danger fa fa-close closeButton'></button></td><td>" + task + "</td><td class='text-right'><input type='number' /></td></tr>");
                $("#todoList tbody").append(newRow);
                $("#itemDropdown").val("");
                if (task === "has created a account within __ days") {
                    newRow.find("input").attr("name", "AccountWithinDays");
                }
                else {
                    newRow.find("input").attr("name", "NotAccountWithinDays");
                }
            }
            else {
                var newRow = $("<tr><td><button class='btn btn-danger fa fa-close closeButton'></button></td><td>" + task + "</td><td class='text-right'><input type='text' /></td></tr>");
                $("#todoList tbody").append(newRow);
                $("#itemDropdown").val("");
                switch (task) {
                    case "email address contains __":
                        newRow.find("input").attr("name", "EmailContains");
                        break;
                    case "email address not contains __":
                        newRow.find("input").attr("name", "EmailNotContains");
                        break;
                    case "first name contains __":
                        newRow.find("input").attr("name", "FirstNameContains");
                        break;
                    case "first name not contains __":
                        newRow.find("input").attr("name", "FirstNameNotContains");
                        break;
                    case "last name contains __":
                        newRow.find("input").attr("name", "LastNameContains");
                        break;
                    case "last name not contains __":
                        newRow.find("input").attr("name", "LastNameNotContains");
                        break;
                }
            }
        }
    });
});

// remove drop down query list
$(document).on("click", ".closeButton", function () {
    const row = $(this).closest("tr");
    const selectedValue = row.find("td:eq(1)").text().trim();

    if (selectedValue) {
        // Find the corresponding option in the dropdown
        const dropdown = $("#itemDropdown");
        const selectedOption = dropdown.find("option[value='" + selectedValue + "']");

        if (selectedOption.length > 0) {
            // Enable the option
            selectedOption.prop("disabled", false);
        }
    }
    $(this).closest("tr").remove();
    SearchQuery(1);
});

// search drop down  query 
function SearchQuery(pageNumber) {
        $("#PageNo").val(pageNumber);
        var formData = $("#DropDownForm").serialize(); // Serialize the form data
    
       $.ajax({
        type: "post", // Use POST or GET based on your controller action method
        url: "/Home/Filter", // Replace with your controller and action names
        data: formData,
        success: function (data) {
            $('#UserFilterListPartial').html(data);
        },
        error: function (error) {
            // Handle errors here
        }
    });
} 

function ChangePage(pageNumber)
{
    PageNumber = pageNumber
    $("#PageNo").val(pageNumber);
    SearchQuery(PageNumber);
}

