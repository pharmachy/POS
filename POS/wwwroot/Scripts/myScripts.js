
var Categories = [];
debugger
//fetch categories from database
function LoadCategory(element) {
    if (Categories.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/PurchaseOrder/GetSubCategoryList',
            success: function (data) {
                Categories = data;
                //render catagory
                
                renderCategory(element);
            }
        })
       // alert(Categories.Name)
    }
    else {
        //render catagory to the element
        renderCategory(element);
    }
}

function renderCategory(element) {
    debugger
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(Categories, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.Name));
        debugger
    });
}

//fetch products
function LoadProducts(categoryId) {
    $.ajax({
        type: "GET",
        url: "/PurchaseOrder/GetProductList",
        data: { 'SubCategoryId': $(categoryId).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderProduct($(categoryId).parents('.mycontainer').find('select.product'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderProduct(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.Id).text(val.ProductName));
    })
}

$(document).ready(function () {
   
    $("#quantity").change(function () {
        Dis();
    });
    $("#rate").change(function () {

        Dis();
    });
    //$("#discount").change(function () {

    //    Dis();
    //});
    $("#NetDiscount").change(function () {
        NetDis();
    });
    function Dis() {

        var Quantity = $("#quantity").val();
        var rate = $("#rate").val();
        var cashValue = parseFloat(Quantity) * parseFloat(rate);
        //var DiscountPer = $("#discount").val();
        //var DisPer = DiscountPer / 100;
        //var Total = cashValue * (1 - DisPer) ;
       // var Total = cashValue;  /* - parseFloat(cashValue);*/
        debugger
        $("#total").val(cashValue);
    }
    function NetDis() {
     
      var fullTotal=  $("#fullTotal").val();
        var DiscountPer = $("#NetDiscount").val();
        var DisPer = DiscountPer / 100;
        var NetTotal = fullTotal * (1 - DisPer);
       
        $("#NetTotal").val(NetTotal);
        
    }
    function Tot() {

       // var r = parseFloat($("#total").val()),
        var sum = 0;
        $(".total").each(function () {
            sum += +this.value;
            $("#fullTotal").val(sum);
            NetDis();
        });

        $('#CompanyId,#BrandId,#BrandModelId').val('0');
        debugger
    }
    //Add button click event
    $('#add').click(function () {
        //validation and add order items
        debugger
        Tot();
        var isAllValid = true;
        if ($('#productCategory').val() == "0") {
            isAllValid = false;
            $('#productCategory').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#productCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#product').val() == "0") {
            isAllValid = false;
            $('#product').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#product').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#quantity').val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
            isAllValid = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#rate').val().trim() != '' && !isNaN($('#rate').val().trim()))) {
            isAllValid = false;
            $('#rate').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#rate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.cr', $newRow).val($('#CategoryId').val());
            $('.pc', $newRow).val($('#productCategory').val());
            $('.product', $newRow).val($('#product').val());
            $('.total', $newRow).val($('#total').val());

            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#CategoryId,#productCategory,#product,#quantity,#rate,#discount,#add,#total', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#CategoryId,#productCategory,#product').val('0');
            $('#quantity,#rate,#discount,#total').val('');
            $('#orderItemError').empty();
           
        }

    })

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        debugger
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
       var Order = $('#orderdetailsItems');
        Order.find("tr").each(function () {
            if (
                $('select.product', this).val() == "0" ||
                (parseInt($('.quantity', this).val()) || 0) == 0 ||
                $('.rate', this).val() == "" ||
                isNaN($('.rate', this).val())
            ) {
                debugger
                errorItemCount++;
                $(this).addClass('error');
            } else {

                var orderItem = {
                    ProductId: $('select.product', this).val(),
                    SubCategoryId: $('select.pc', this).val(),
                    SupplierId: $('select.SupplierId', this).val(),
                    Quantity: parseInt($('.quantity', this).val()),
                    Rate: parseFloat($('.rate', this).val()),
                    DiscountPer: parseFloat($('.discount', this).val()),
                    TotalAmount: parseFloat($('.total', this).val())


                }
                list.push(orderItem);
                isAllValid;
                debugger
            }
           
        } );
        debugger
        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        //if ($('#orderNo').val().trim() == '') {
        //    $('#orderNo').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //}
        //else {
        //    $('#orderNo').siblings('span.error').css('visibility', 'hidden');
        //}
        if ($('#orderDate').val().trim() == '') {
           $('#orderErr').css('visibility', 'visible');
         //   $('#orderErr').css({ "backgroundColor": "black", "color": "red"});
            isAllValid = false;
            debugger
        } else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
            debugger
        }
        //if ($('#orderDate').val().trim() == '') {orderErr
        //    $('#orderDate').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //    debugger
        //}(!($('#SupplierId').val().trim() != '' && (parseInt($('#SupplierId').val()) || 0)))
        if (!($('#SupplierId').val().trim() != '' && (parseInt($('#SupplierId').val()) || 0))) {
            $('#SupplierErr').css('visibility', 'visible');
          //  $('#SupplierId').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
            debugger  }
        else {
            $('#SupplierErr').css('visibility', 'hidden');
            debugger }

        if (isAllValid) {
            var data = {
                //OrderNo: $('#orderNo').val().trim(),
                OrderDate: $('#orderDate').val().trim(),
                DeliveryDate: $('#DeliveryDate').val().trim(),
                Description: $('#description').val().trim(),
                SupplierId: $('#SupplierId').val().trim(),
                NetDiscount: $('#NetDiscount').val(),
                NetTotal: $('#NetTotal').val(),
                OrderDetail: list
            }

            $(this).val('Please wait...');
            debugger
            $.ajax({
                type: 'POST',
                url: '/PurchaseOrder/save',
               // data: JSON.stringify(data),
                data: data,
              //  contentType: 'application/json',
                success: function (data) {
                    if (data) {
                        alert('Successfully saved');
                        //here we will clear the form
                        //list = [];
                        //$('#orderNo,#orderDate,#description').val('');
                        //$('#orderdetailsItems').empty();
                      //  window.location.href = '@Url.Action("PurchaseOrder", "PoList")';
                        window.location.href = 'PoList';
                       // location.reload();
                    }
                    else {
                        alert('Error');
                        location.reload();
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').val('Save');
                }
            });
        }

    });

});

LoadCategory($('#productCategory'));