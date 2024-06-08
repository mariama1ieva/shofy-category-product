const heroSwiper = new Swiper(".hero-swiper", {
  direction: "horizontal",
  loop: false,
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  navigation: {
    nextEl: ".hero-nav-next",
    prevEl: ".hero-nav-prev",
  },
});

const offerSwiper = new Swiper(".offer-slider", {
  direction: "horizontal",
  slidesPerView: 1,

  breakpoints: {
    768: {
      slidesPerView: 2,
      spaceBetween: 10,
    },

    1200: {
      slidesPerView: 3,
      spaceBetween: 30,
    },
  },
  pagination: {
    el: ".offer-pagination",
    clickable: true,
  },
});
const tabletSwiper = new Swiper(".tablet-swiper", {
  direction: "vertical",
  loop: false,
  slidesPerView: 1,
  pagination: {
    el: ".vertical-pagination",
    clickable: true,
  },
});
const naSwiper = new Swiper(".new-arrivals-swiper", {
  direction: "horizontal",
  slidesPerView: 1,

  breakpoints: {
    576: {
      slidesPerView: 2,
      spaceBetween: 10,
    },

    992: {
      slidesPerView: 3,
      spaceBetween: 20,
    },

    1200: {
      slidesPerView: 4,
      spaceBetween: 30,
    },
  },

  navigation: {
    nextEl: ".na-nextt",
    prevEl: ".na-prevv",
  },
});

const articlesSwiper = new Swiper(".articles-swiper", {
  direction: "horizontal",
  slidesPerView: 1,
  spaceBetween: 20,
  breakpoints: {
    576: {
      slidesPerView: 2,
      spaceBetween: 10,
    },

    1200: {
      slidesPerView: 3,
      spaceBetween: 20,
    },
  },
});
const newProductsTab = document.querySelector(".trending-items-tab");
const tabButtons = newProductsTab.querySelectorAll(".np-btn");
const tabPanels = document.querySelectorAll(".tab-panel");
function showTab(tabId) {
  tabPanels.forEach((panel) => {
    panel.style.display = "none";
    panel.classList.remove("show");
  });

  const selectedPanel = document.getElementById(tabId);
  if (selectedPanel) {
    selectedPanel.style.display = "block";
    selectedPanel.classList.add("show");
  }
}
tabButtons.forEach((button) => {
  button.addEventListener("click", function () {
    tabButtons.forEach((btn) => {
      btn.classList.remove("active");
    });
    this.classList.add("active");
    const targetTab = this.getAttribute("aria-controls");
    showTab(targetTab);
  });
});
if (tabButtons.length > 0) {
  const firstButton = tabButtons[0];
  const firstTab = firstButton.getAttribute("aria-controls");
  showTab(firstTab);
  firstButton.classList.add("active");
}
