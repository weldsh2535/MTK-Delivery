!function(){function t(t,e){if(!(t instanceof e))throw new TypeError("Cannot call a class as a function")}function e(t,e){for(var i=0;i<e.length;i++){var n=e[i];n.enumerable=n.enumerable||!1,n.configurable=!0,"value"in n&&(n.writable=!0),Object.defineProperty(t,n.key,n)}}function i(t,i,n){return i&&e(t.prototype,i),n&&e(t,n),t}(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{"QR/W":function(e,n,o){"use strict";o.r(n),o.d(n,"DetailsPageModule",function(){return P});var r,s=o("ofXK"),c=o("3Pt+"),a=o("TEn/"),d=o("tyNb"),l=o("mrSG"),u=o("fXoL"),f=o("1Bn7"),h=o("Vefk"),b=o("Dkj+"),g=o("+cje"),p=o("neG8"),v=o("VNSQ"),m=o("ldse"),y=((r=function(){function e(i){t(this,e),this.domCtrl=i}return i(e,[{key:"onContentScroll",value:function(t){var e=t.detail.scrollTop;e>0?(this.moveImage=e/1.6,this.scaleImage=1):(this.scaleImage=-e/200+1,this.moveImage=e/1.6)}}]),e}()).\u0275fac=function(t){return new(t||r)(u.Qb(a.c))},r.\u0275dir=u.Lb({type:r,selectors:[["","appParallax",""]],hostBindings:function(t,e){1&t&&u.gc("ionScroll",function(t){return e.onContentScroll(t)})},inputs:{imageEl:["appParallax","imageEl"]}}),r),k=["cart"];function O(t,e){if(1&t&&(u.Vb(0,"ion-badge"),u.Ec(1),u.jc(2,"async"),u.Ub()),2&t){var i=u.ic();u.Eb(1),u.Fc(u.kc(2,1,i.cartItemCount))}}function x(t,e){if(1&t){var i=u.Wb();u.Vb(0,"ion-slide"),u.Vb(1,"ion-button",15),u.gc("click",function(){u.wc(i);var t=e.index;return u.ic().activeCategory=t})("click",function(){u.wc(i);var t=e.index,n=e.$implicit;return u.ic().selectCategory(t,n.id)}),u.Ec(2),u.Ub(),u.Ub()}if(2&t){var n=e.$implicit,o=e.index,r=u.ic();u.Eb(1),u.Ib("active-category",r.activeCategory==o),u.Eb(1),u.Gc(" ",n.categoryName," ")}}function C(t,e){if(1&t){var i=u.Wb();u.Vb(0,"ion-row",16),u.Vb(1,"ion-col",17),u.Rb(2,"div",18),u.Ub(),u.Vb(3,"ion-col",19),u.Vb(4,"ion-label"),u.Ec(5),u.Vb(6,"p"),u.Ec(7),u.Ub(),u.Ub(),u.Vb(8,"ion-text",20),u.Vb(9,"b"),u.Ec(10),u.jc(11,"currency"),u.Ub(),u.Ub(),u.Ub(),u.Vb(12,"ion-col",21),u.Vb(13,"ion-button",22),u.gc("click",function(){u.wc(i);var t=e.$implicit,n=e.index;return u.ic().addToCart(t,n)}),u.Rb(14,"ion-icon",23),u.Ub(),u.Ub(),u.Ub()}if(2&t){var n=e.$implicit,o=u.ic();u.Eb(2),u.zc("background-image","url("+n.picture+")"),u.Eb(3),u.Gc(" ",n.name," "),u.Eb(2),u.Fc(n.description),u.Eb(3),u.Fc(u.lc(11,7,n.price,"ETB")),u.Eb(3),u.oc("disabled",o.setDisabled(n)),u.Eb(1),u.oc("name",n.isSelect?"checkmark":"add")}}var F,I,w,E=[{path:"",component:(F=function(){function e(i,n,o,r,s,c,a,d,l,u,f){var h=this;t(this,e),this.foodService=i,this.Activatedroute=n,this.restaurantservice=o,this.categoryService=r,this.router=s,this.modalCtrl=c,this.orderService=a,this.sharedService=d,this.alertController=l,this.toastController=u,this.document=f,this.data=null,this.opts={freeMode:!0,slidesPerView:4.6,slidesOffsetBefore:100,slidesOffsetAfter:100},this.activeCategory=0,this.listElements=[],this.categorySlidesVisible=!1,this.listOfCategory=[],this.catagories=[],this.cart=[],this.visible=!1,this.checkIndex=[],this.isenabled=!0,this.dayFinished=[],this.restaurantservice.getAllRestaurant().subscribe(function(t){h.listOfRestaurant=t,h.name=t.find(function(t){return t.id===h.resId}).name,h.picture=t.find(function(t){return t.id===h.resId}).photo})}return i(e,[{key:"ngOnInit",value:function(){this.dayFinished.push(this.Activatedroute.snapshot.paramMap.get("id")),this.cart=this.orderService.getCart(),this.cartItemCount=this.orderService.getCartItemCount(),this.id=this.Activatedroute.snapshot.paramMap.get("id"),this.resId=this.sharedService.getRestaurantId().value,this.orderService.RestaurantId.next(this.id),console.log(this.resId);var t=Object(f.l)("ios")?44:56;this.document.documentElement.style.setProperty("--header-position","calc(env(safe-area-inset-top) + ".concat(t,"px)")),this.getRestaurant(),this.getFood(),this.getCategory()}},{key:"getFood",value:function(){var t=this;this.foodService.getAllFood().subscribe(function(e){t.getCheckDisable_selecet(e),t.listOfFood=e.filter(function(e){return e.restaurantId===t.resId.toString()}),t.restaurantservice.getAllRestaurant().subscribe(function(e){e.find(function(e){return e.id===t.resId&&"close"===e.status})&&t.listOfFood.forEach(function(e){for(var i=0;i<=t.listOfFood.length;i++)t.checkIndex.push({index:i,item:e.id});t.dayFinished.includes(e)?t.dayFinished.splice(t.dayFinished.indexOf(e),1):t.dayFinished.push(e)})})})}},{key:"getCheckDisable_selecet",value:function(t){var e=this;this.listOfFood=t;for(var i=0;i<this.cart.length;i++)for(var n=0;n<this.listOfFood.length;n++)this.cart[i].id==t[n].id?(this.listOfFood[n].isSelect=!0,this.checkIndex.push({index:n,item:this.listOfFood[n].id}),void 0!==this.checkIndex&&this.checkIndex.forEach(function(i){var n=e.listOfFood.find(function(t){return t.id===i.item});if(i.item===t.id)e.listOfFood[i.index].isSelect=!0;else if(void 0!==n){var o=e.listOfFood.findIndex(function(t){return t.id===i.item});e.listOfFood[o].isSelect=!0}})):this.listOfFood[n].isSelect=!1;if(0!==this.cart.length)for(var o=0;o<this.cart.length;o++)for(i=0;i<t.length;i++)this.cart[o].id==t[i].id&&this.dayFinished.push(t[i])}},{key:"getCategory",value:function(){var t=this;this.categoryService.getAllCategory().subscribe(function(e){t.restaurantservice.getAllRestaurant().subscribe(function(i){var n=i.find(function(e){return e.id===t.resId}).categoryId;if(void 0!==n)for(var o=function(i){var o=e.find(function(t){return t.categoryName===n[i]});t.listOfCategory.push({id:o.id,categoryName:n[i]}),console.log(t.listOfCategory)},r=0;r<n.length;r++)o(r)})})}},{key:"getRestaurant",value:function(){var t=this;this.restaurantservice.getAllRestaurant().subscribe(function(e){t.listOfRestaurant=e,t.name=e.find(function(e){return e.id===t.resId}).name,t.picture=e.find(function(e){return e.id===t.resId}).photo})}},{key:"ngAfterViewInit",value:function(){var t=this;this.lists.changes.subscribe(function(e){t.listElements=t.lists.toArray()})}},{key:"selectCategory",value:function(t,e){var i=this;this.foodService.getAllFood().subscribe(function(t){i.listOfFood=t.filter(function(t){return t.categoryId===e&&t.restaurantId===i.resId.toString()}),i.listOfFood.length>0&&i.checkIndex.forEach(function(t){if(void 0!==i.listOfFood.find(function(e){return e.id===t.item})){var e=i.listOfFood.findIndex(function(e){return e.id===t.item});i.listOfFood[e].isSelect=!0}}),i.listOfFood.forEach(function(t){void 0!==i.checkIndex.find(function(e){return e.item===t.id})&&(i.dayFinished.includes(t)?i.dayFinished.splice(i.dayFinished.indexOf(t),1):i.dayFinished.push(t))})})}},{key:"onScroll",value:function(t){this.categorySlidesVisible=t.detail.scrollTop>1500;for(var e=0;e<this.listElements.length;e++)if(this.isElementInViewport(this.listElements[e].nativeElement)){this.activeCategory=e,this.slides.slideTo(e);break}}},{key:"isElementInViewport",value:function(t){var e=t.getBoundingClientRect();return e.top>=0&&e.bottom<=(window.innerHeight||document.documentElement.clientHeight)}},{key:"setDisabled",value:function(t){return this.dayFinished.includes(t)}},{key:"addToCart",value:function(t,e){0===this.cart.length||this.cart[0].restaurantId==t.restaurantId&&(0==e||this.resId===+t.restaurantId)?this.getAddToCart(t,e):this.presentAlert("Switching Restaurant is not allowed")}},{key:"getAddToCart",value:function(t,e){for(var i=this,n=0;n<this.listOfFood.length;n++)e===n?(this.listOfFood[n].isSelect=!0,this.checkIndex.push({index:n,item:t.id}),void 0!==this.checkIndex&&this.checkIndex.forEach(function(e){var n=i.listOfFood.find(function(t){return t.id===e.item});if(e.item===t.id)i.listOfFood[e.index].isSelect=!0;else if(void 0!==n){var o=i.listOfFood.findIndex(function(t){return t.id===e.item});i.listOfFood[o].isSelect=!0}})):this.listOfFood[n].isSelect=!1;this.dayFinished.includes(t)?this.dayFinished.splice(this.dayFinished.indexOf(t),1):this.dayFinished.push(t),this.orderService.addProduct(t)}},{key:"presentAlert",value:function(t){return Object(l.a)(this,void 0,void 0,regeneratorRuntime.mark(function e(){var i;return regeneratorRuntime.wrap(function(e){for(;;)switch(e.prev=e.next){case 0:return e.next=2,this.toastController.create({color:"warning",duration:2e3,message:t});case 2:return i=e.sent,e.next=5,i.present();case 5:case"end":return e.stop()}},e,this)}))}},{key:"onClick",value:function(){this.router.navigate(["/menu/cart-modal"])}},{key:"backToHome",value:function(){this.router.navigate(["/menu/home"])}},{key:"openCart",value:function(){return Object(l.a)(this,void 0,void 0,regeneratorRuntime.mark(function t(){return regeneratorRuntime.wrap(function(t){for(;;)switch(t.prev=t.next){case 0:return t.next=2,this.modalCtrl.create({component:h.a,cssClass:"cart-modal"});case 2:t.sent.present();case 3:case"end":return t.stop()}},t,this)}))}}]),e}(),F.\u0275fac=function(t){return new(t||F)(u.Qb(b.a),u.Qb(d.a),u.Qb(g.a),u.Qb(p.a),u.Qb(d.g),u.Qb(a.V),u.Qb(v.a),u.Qb(m.a),u.Qb(a.a),u.Qb(a.bb),u.Qb(s.e))},F.\u0275cmp=u.Kb({type:F,selectors:[["app-details"]],viewQuery:function(t,e){var i;1&t&&(u.Ic(a.M,1),u.Ic(a.l,1),u.Ic(k,1,u.m),u.Ic(a.y,1,u.m)),2&t&&(u.uc(i=u.hc())&&(e.slides=i.first),u.uc(i=u.hc())&&(e.content=i.first),u.uc(i=u.hc())&&(e.fab=i.first),u.uc(i=u.hc())&&(e.lists=i))},decls:18,vars:9,consts:[["color","light"],["slot","start"],["fill","solid","shape","round","color","light",3,"click"],["slot","icon-only","name","arrow-back","color","primary"],["slot","end"],[3,"click"],[4,"ngIf"],["slot","icon-only","name","cart"],["scrollEvents","true",3,"fullscreen","appParallax","ionScroll"],[1,"header-image"],["img",""],[1,"sticky-row"],[3,"options"],[4,"ngFor","ngForOf"],["class","ion-padding meal-row",4,"ngFor","ngForOf"],["fill","clear",3,"click"],[1,"ion-padding","meal-row"],["size","4",1,"border-bottom"],[1,"meal-image"],["size","5",1,"border-bottom"],["color","dark"],["size","3",1,"border-bottom"],["fill","solid",3,"disabled","click"],[3,"name"]],template:function(t,e){if(1&t&&(u.Vb(0,"ion-header"),u.Vb(1,"ion-toolbar",0),u.Vb(2,"ion-buttons",1),u.Vb(3,"ion-button",2),u.gc("click",function(){return e.backToHome()}),u.Rb(4,"ion-icon",3),u.Ub(),u.Ub(),u.Vb(5,"ion-title"),u.Ec(6),u.Ub(),u.Vb(7,"ion-buttons",4),u.Vb(8,"ion-button",5),u.gc("click",function(){return e.onClick()}),u.Cc(9,O,3,3,"ion-badge",6),u.Rb(10,"ion-icon",7),u.Ub(),u.Ub(),u.Ub(),u.Ub(),u.Vb(11,"ion-content",8),u.gc("ionScroll",function(t){return e.onScroll(t)}),u.Rb(12,"div",9,10),u.Vb(14,"ion-row",11),u.Vb(15,"ion-slides",12),u.Cc(16,x,3,3,"ion-slide",13),u.Ub(),u.Ub(),u.Cc(17,C,15,10,"ion-row",14),u.Ub()),2&t){var i=u.vc(13);u.Eb(6),u.Fc(e.name),u.Eb(3),u.oc("ngIf",e.cart.length>0),u.Eb(2),u.oc("fullscreen",!0)("appParallax",i),u.Eb(1),u.zc("background-image","url("+e.picture+")"),u.Eb(3),u.oc("options",e.opts),u.Eb(1),u.oc("ngForOf",e.listOfCategory),u.Eb(1),u.oc("ngForOf",e.listOfFood)}},directives:[a.r,a.R,a.j,a.i,a.s,a.P,s.n,a.l,y,a.F,a.M,s.m,a.h,a.L,a.k,a.x,a.O],pipes:[s.b,s.d],styles:["ion-toolbar[_ngcontent-%COMP%]   ion-icon[_ngcontent-%COMP%]{font-size:25px}ion-content[_ngcontent-%COMP%]{position:absolute;--background:#f1f1f1;--padding-bottom:50px}.light-bg[_ngcontent-%COMP%]{background:#fff;z-index:10}.header-image[_ngcontent-%COMP%]{background-repeat:no-repeat;background-position:50%;background-size:cover;height:30vh;will-change:transform}ion-list-header[_ngcontent-%COMP%]{--background:#a0b67d}ion-list[_ngcontent-%COMP%]{--ion-background-color:#3d85a7}.meal-row[_ngcontent-%COMP%]{padding-bottom:0}.meal-image[_ngcontent-%COMP%]{width:100%;height:100%;background-position:50%;background-size:cover;background-repeat:no-repeat;border-radius:5px}.border-bottom[_ngcontent-%COMP%]{border-bottom:1px solid var(--ion-color-step-150,rgba(0,0,0,.07))}ion-slides[_ngcontent-%COMP%]{padding-right:0;margin-top:34px;margin-bottom:-34px;background:hsla(0,0%,72.5%,.9215686274509803);top:calc(env(safe-area-inset-top) - 34px)}.slides-visible[_ngcontent-%COMP%]{opacity:1;transition:1s}.slides-hidden[_ngcontent-%COMP%]{opacity:0;transition:1s}.active-category[_ngcontent-%COMP%]{--background:var(--ion-color-primary);--color:#fff;--border-radius:10px;font-weight:600}ion-badge[_ngcontent-%COMP%]{color:#fff;position:absolute;top:-9px;right:2px;border-radius:100%}.cart-icon[_ngcontent-%COMP%]{font-size:50px}.cart-length[_ngcontent-%COMP%]{color:var(--ion-color-primary);position:absolute;top:18px;left:25px;font-weight:600;font-size:1em;min-width:25px;z-index:10}.sticky-row[_ngcontent-%COMP%]{position:sticky;top:calc(env(safe-area-inset-top) - -55px);z-index:2;background:hsla(0,0%,72.5%,.9215686274509803);box-shadow:0 9px 11px -15px rgba(0,0,0,.75);display:flex;flex-direction:row;align-items:flex-end}"]}),F)}],S=((I=function e(){t(this,e)}).\u0275fac=function(t){return new(t||I)},I.\u0275mod=u.Ob({type:I}),I.\u0275inj=u.Nb({imports:[[d.j.forChild(E)],d.j]}),I),V=o("bLo3"),P=((w=function e(){t(this,e)}).\u0275fac=function(t){return new(t||w)},w.\u0275mod=u.Ob({type:w}),w.\u0275inj=u.Nb({imports:[[s.c,c.e,a.S,V.a,S]]}),w)}}])}();