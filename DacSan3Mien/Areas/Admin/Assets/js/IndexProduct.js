$(document).ready(function () {
    $('.product-list tr').each(function () {
        let productId = $(this).find("#product-id").html();
        $(this).find(".delete-product").on('click', function () {
            swal({
                title: "Bạn có muốn xóa không?",
                text: "Bạn sẽ xóa sản phẩm này khỏi hệ thống!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Xóa!",
                cancelButtonText: "Không!",
                closeOnConfirm: false,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        window.location.href = '/Admin/Product/Delete/' + productId;
                    }
                }
            );
        });
    })

    $('.user-list tr').each(function () {
        let userId = $(this).find("#user-id").html();
        $(this).find(".delete-user").on('click', function () {
            swal({
                title: "Bạn có muốn xóa không?",
                text: "Bạn sẽ xóa người dùng này khỏi hệ thống!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Xóa!",
                cancelButtonText: "Không!",
                closeOnConfirm: false,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        window.location.href = '/Admin/User/Delete/' + userId;
                    }
                }
            );
        });
    })

    $('.order-list tr').each(function () {
        let orderId = $(this).find("#order-id").html();
        let userId = $(this).find("#user-id").val();
        let productId = $(this).find("#product-id").val();
        $(this).find(".delete-order").on('click', function () {
            debugger
            swal({
                title: "Bạn có muốn xóa không?",
                text: "Bạn sẽ xóa đơn hàng này khỏi hệ thống!",
                type: "warning",
                showCancelButton: true,
                confirmButtonClass: "btn-danger",
                confirmButtonText: "Xóa!",
                cancelButtonText: "Không!",
                closeOnConfirm: false,
                closeOnCancel: true
            },
                function (isConfirm) {
                    if (isConfirm) {
                        $.ajax({
                            type: "Post",
                            data: {
                                id: orderId,
                                userId: userId,
                                productId: productId
                            },
                            url: "Order/Delete",
                            success: function (result) {
                                location.reload(result);
                            }
                        });
                    }
                }
            );
        });
    })
});