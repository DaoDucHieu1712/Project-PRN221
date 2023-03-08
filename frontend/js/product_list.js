const btn_create = document.querySelector(".create");
const btn_delete = document.querySelectorAll(".delete");
const btn_update = document.querySelectorAll(".update");

//HELPER
const insert_template = (template) => {
  document.body.insertAdjacentHTML("beforeend", template);
};

function get_template(url, method) {
  return $.ajax({
    url: url,
    type: method,
    success: function (response) {
      return response;
    },
    error: function (xhr) {},
  });
}

//CREATE
btn_create.addEventListener("click", (e) => {
  console.log("create");

  let template = get_template(
    "http://127.0.0.1:5500/Frontend/product_create.html",
    "get"
  ).then((res) => {
    insert_template(res);
  });
});

//UPDATE
btn_update.forEach((item) =>
  item.addEventListener("click", (e) => {
    const value = e.target.dataset.valueId;
    console.log(value);
    console.log("update");
    let template = get_template(
      "http://127.0.0.1:5500/Frontend/product_update.html",
      "get"
    ).then((res) => {
      insert_template(res);
    });
  })
);

// btn_update.addEventListener("click", () => {
//   console.log("update");
//   let template = get_template(
//     "http://127.0.0.1:5500/Frontend/product_update.html",
//     "get"
//   ).then((res) => {
//     insert_template(res);
//   });
// });

//DELETE
btn_delete.forEach((item) =>
  item.addEventListener("click", () => {
    console.log("delte");
    let template = get_template(
      "http://127.0.0.1:5500/Frontend/product_delete.html",
      "get"
    ).then((res) => {
      insert_template(res);
    });
  })
);

//CLOSE MODAL
document.body.addEventListener("click", (e) => {
  if (e.target.matches(".modal-close")) {
    const modal = e.target.parentNode.parentNode;
    modal.parentNode.removeChild(modal);
  } else if (e.target.matches(".modal-overlay")) {
    const modal = e.target.parentNode;
    modal.parentNode.removeChild(modal);
  } else if (e.target.matches(".close-delete")) {
    const modal = e.target.parentNode.parentNode.parentNode.parentNode;
    modal.parentNode.removeChild(modal);
  }
});
