(window.webpackJsonp=window.webpackJsonp||[]).push([[25],{"QR/W":function(t,i,e){"use strict";e.r(i),e.d(i,"DetailsPageModule",function(){return k});var o=e("ofXK"),s=e("3Pt+"),n=e("TEn/"),r=e("tyNb"),c=e("mrSG"),a=e("fXoL"),d=e("1Bn7"),l=e("Vefk"),h=e("Dkj+"),b=e("+cje"),g=e("neG8"),f=e("VNSQ"),u=e("ldse");let p=(()=>{class t{constructor(t){this.domCtrl=t}onContentScroll(t){const i=t.detail.scrollTop;i>0?(this.moveImage=i/1.6,this.scaleImage=1):(this.scaleImage=-i/200+1,this.moveImage=i/1.6)}}return t.\u0275fac=function(i){return new(i||t)(a.Qb(n.c))},t.\u0275dir=a.Lb({type:t,selectors:[["","appParallax",""]],hostBindings:function(t,i){1&t&&a.gc("ionScroll",function(t){return i.onContentScroll(t)})},inputs:{imageEl:["appParallax","imageEl"]}}),t})();const m=["cart"];function y(t,i){if(1&t&&(a.Vb(0,"ion-badge"),a.Ec(1),a.jc(2,"async"),a.Ub()),2&t){const t=a.ic();a.Eb(1),a.Fc(a.kc(2,1,t.cartItemCount))}}function O(t,i){if(1&t){const t=a.Wb();a.Vb(0,"ion-slide"),a.Vb(1,"ion-button",15),a.gc("click",function(){a.wc(t);const e=i.index;return a.ic().activeCategory=e})("click",function(){a.wc(t);const e=i.index,o=i.$implicit;return a.ic().selectCategory(e,o.id)}),a.Ec(2),a.Ub(),a.Ub()}if(2&t){const t=i.$implicit,e=i.index,o=a.ic();a.Eb(1),a.Ib("active-category",o.activeCategory==e),a.Eb(1),a.Gc(" ",t.categoryName," ")}}function v(t,i){if(1&t){const t=a.Wb();a.Vb(0,"ion-row",16),a.Vb(1,"ion-col",17),a.Rb(2,"div",18),a.Ub(),a.Vb(3,"ion-col",19),a.Vb(4,"ion-label"),a.Ec(5),a.Vb(6,"p"),a.Ec(7),a.Ub(),a.Ub(),a.Vb(8,"ion-text",20),a.Vb(9,"b"),a.Ec(10),a.jc(11,"currency"),a.Ub(),a.Ub(),a.Ub(),a.Vb(12,"ion-col",21),a.Vb(13,"ion-button",22),a.gc("click",function(){a.wc(t);const e=i.$implicit,o=i.index;return a.ic().addToCart(e,o)}),a.Rb(14,"ion-icon",23),a.Ub(),a.Ub(),a.Ub()}if(2&t){const t=i.$implicit,e=a.ic();a.Eb(2),a.zc("background-image","url("+t.picture+")"),a.Eb(3),a.Gc(" ",t.name," "),a.Eb(2),a.Fc(t.description),a.Eb(3),a.Fc(a.lc(11,7,t.price,"ETB")),a.Eb(3),a.oc("disabled",e.setDisabled(t)),a.Eb(1),a.oc("name",t.isSelect?"checkmark":"add")}}const C=[{path:"",component:(()=>{class t{constructor(t,i,e,o,s,n,r,c,a,d,l){this.foodService=t,this.Activatedroute=i,this.restaurantservice=e,this.categoryService=o,this.router=s,this.modalCtrl=n,this.orderService=r,this.sharedService=c,this.alertController=a,this.toastController=d,this.document=l,this.data=null,this.opts={freeMode:!0,slidesPerView:4.6,slidesOffsetBefore:100,slidesOffsetAfter:100},this.activeCategory=0,this.listElements=[],this.categorySlidesVisible=!1,this.listOfCategory=[],this.catagories=[],this.cart=[],this.visible=!1,this.checkIndex=[],this.isenabled=!0,this.dayFinished=[],this.restaurantservice.getAllRestaurant().subscribe(t=>{this.listOfRestaurant=t,this.name=t.find(t=>t.id===this.resId).name,this.picture=t.find(t=>t.id===this.resId).photo})}ngOnInit(){this.dayFinished.push(this.Activatedroute.snapshot.paramMap.get("id")),this.cart=this.orderService.getCart(),this.cartItemCount=this.orderService.getCartItemCount(),this.id=this.Activatedroute.snapshot.paramMap.get("id"),this.resId=this.sharedService.getRestaurantId().value,this.orderService.RestaurantId.next(this.id),console.log(this.resId);const t=Object(d.l)("ios")?44:56;this.document.documentElement.style.setProperty("--header-position",`calc(env(safe-area-inset-top) + ${t}px)`),this.getRestaurant(),this.getFood(),this.getCategory()}getFood(){this.foodService.getAllFood().subscribe(t=>{this.getCheckDisable_selecet(t),this.listOfFood=t.filter(t=>t.restaurantId===this.resId.toString()),this.restaurantservice.getAllRestaurant().subscribe(t=>{t.find(t=>t.id===this.resId&&"close"===t.status)&&this.listOfFood.forEach(t=>{for(let i=0;i<=this.listOfFood.length;i++)this.checkIndex.push({index:i,item:t.id});this.dayFinished.includes(t)?this.dayFinished.splice(this.dayFinished.indexOf(t),1):this.dayFinished.push(t)})})})}getCheckDisable_selecet(t){this.listOfFood=t;for(var i=0;i<this.cart.length;i++)for(let e=0;e<this.listOfFood.length;e++)this.cart[i].id==t[e].id?(this.listOfFood[e].isSelect=!0,this.checkIndex.push({index:e,item:this.listOfFood[e].id}),void 0!==this.checkIndex&&this.checkIndex.forEach(i=>{const e=this.listOfFood.find(t=>t.id===i.item);if(i.item===t.id)this.listOfFood[i.index].isSelect=!0;else if(void 0!==e){const t=this.listOfFood.findIndex(t=>t.id===i.item);this.listOfFood[t].isSelect=!0}})):this.listOfFood[e].isSelect=!1;if(0!==this.cart.length)for(var e=0;e<this.cart.length;e++)for(i=0;i<t.length;i++)this.cart[e].id==t[i].id&&this.dayFinished.push(t[i])}getCategory(){this.categoryService.getAllCategory().subscribe(t=>{this.restaurantservice.getAllRestaurant().subscribe(i=>{const e=i.find(t=>t.id===this.resId).categoryId;if(void 0!==e)for(let o=0;o<e.length;o++){const i=t.find(t=>t.categoryName===e[o]);this.listOfCategory.push({id:i.id,categoryName:e[o]}),console.log(this.listOfCategory)}})})}getRestaurant(){this.restaurantservice.getAllRestaurant().subscribe(t=>{this.listOfRestaurant=t,this.name=t.find(t=>t.id===this.resId).name,this.picture=t.find(t=>t.id===this.resId).photo})}ngAfterViewInit(){this.lists.changes.subscribe(t=>{this.listElements=this.lists.toArray()})}selectCategory(t,i){this.foodService.getAllFood().subscribe(t=>{this.listOfFood=t.filter(t=>t.categoryId===i&&t.restaurantId===this.resId.toString()),this.listOfFood.length>0&&this.checkIndex.forEach(t=>{if(void 0!==this.listOfFood.find(i=>i.id===t.item)){const i=this.listOfFood.findIndex(i=>i.id===t.item);this.listOfFood[i].isSelect=!0}}),this.listOfFood.forEach(t=>{void 0!==this.checkIndex.find(i=>i.item===t.id)&&(this.dayFinished.includes(t)?this.dayFinished.splice(this.dayFinished.indexOf(t),1):this.dayFinished.push(t))})})}onScroll(t){this.categorySlidesVisible=t.detail.scrollTop>1500;for(let i=0;i<this.listElements.length;i++)if(this.isElementInViewport(this.listElements[i].nativeElement)){this.activeCategory=i,this.slides.slideTo(i);break}}isElementInViewport(t){const i=t.getBoundingClientRect();return i.top>=0&&i.bottom<=(window.innerHeight||document.documentElement.clientHeight)}setDisabled(t){return this.dayFinished.includes(t)}addToCart(t,i){0===this.cart.length||this.cart[0].restaurantId==t.restaurantId&&(0==i||this.resId===+t.restaurantId)?this.getAddToCart(t,i):this.presentAlert("Switching Restaurant is not allowed")}getAddToCart(t,i){for(let e=0;e<this.listOfFood.length;e++)i===e?(this.listOfFood[e].isSelect=!0,this.checkIndex.push({index:e,item:t.id}),void 0!==this.checkIndex&&this.checkIndex.forEach(i=>{const e=this.listOfFood.find(t=>t.id===i.item);if(i.item===t.id)this.listOfFood[i.index].isSelect=!0;else if(void 0!==e){const t=this.listOfFood.findIndex(t=>t.id===i.item);this.listOfFood[t].isSelect=!0}})):this.listOfFood[e].isSelect=!1;this.dayFinished.includes(t)?this.dayFinished.splice(this.dayFinished.indexOf(t),1):this.dayFinished.push(t),this.orderService.addProduct(t)}presentAlert(t){return Object(c.a)(this,void 0,void 0,function*(){const i=yield this.toastController.create({color:"warning",duration:2e3,message:t});yield i.present()})}onClick(){this.router.navigate(["/menu/cart-modal"])}backToHome(){this.router.navigate(["/menu/home"])}openCart(){return Object(c.a)(this,void 0,void 0,function*(){(yield this.modalCtrl.create({component:l.a,cssClass:"cart-modal"})).present()})}}return t.\u0275fac=function(i){return new(i||t)(a.Qb(h.a),a.Qb(r.a),a.Qb(b.a),a.Qb(g.a),a.Qb(r.g),a.Qb(n.V),a.Qb(f.a),a.Qb(u.a),a.Qb(n.a),a.Qb(n.bb),a.Qb(o.e))},t.\u0275cmp=a.Kb({type:t,selectors:[["app-details"]],viewQuery:function(t,i){if(1&t&&(a.Ic(n.M,1),a.Ic(n.l,1),a.Ic(m,1,a.m),a.Ic(n.y,1,a.m)),2&t){let t;a.uc(t=a.hc())&&(i.slides=t.first),a.uc(t=a.hc())&&(i.content=t.first),a.uc(t=a.hc())&&(i.fab=t.first),a.uc(t=a.hc())&&(i.lists=t)}},decls:18,vars:9,consts:[["color","light"],["slot","start"],["fill","solid","shape","round","color","light",3,"click"],["slot","icon-only","name","arrow-back","color","primary"],["slot","end"],[3,"click"],[4,"ngIf"],["slot","icon-only","name","cart"],["scrollEvents","true",3,"fullscreen","appParallax","ionScroll"],[1,"header-image"],["img",""],[1,"sticky-row"],[3,"options"],[4,"ngFor","ngForOf"],["class","ion-padding meal-row",4,"ngFor","ngForOf"],["fill","clear",3,"click"],[1,"ion-padding","meal-row"],["size","4",1,"border-bottom"],[1,"meal-image"],["size","5",1,"border-bottom"],["color","dark"],["size","3",1,"border-bottom"],["fill","solid",3,"disabled","click"],[3,"name"]],template:function(t,i){if(1&t&&(a.Vb(0,"ion-header"),a.Vb(1,"ion-toolbar",0),a.Vb(2,"ion-buttons",1),a.Vb(3,"ion-button",2),a.gc("click",function(){return i.backToHome()}),a.Rb(4,"ion-icon",3),a.Ub(),a.Ub(),a.Vb(5,"ion-title"),a.Ec(6),a.Ub(),a.Vb(7,"ion-buttons",4),a.Vb(8,"ion-button",5),a.gc("click",function(){return i.onClick()}),a.Cc(9,y,3,3,"ion-badge",6),a.Rb(10,"ion-icon",7),a.Ub(),a.Ub(),a.Ub(),a.Ub(),a.Vb(11,"ion-content",8),a.gc("ionScroll",function(t){return i.onScroll(t)}),a.Rb(12,"div",9,10),a.Vb(14,"ion-row",11),a.Vb(15,"ion-slides",12),a.Cc(16,O,3,3,"ion-slide",13),a.Ub(),a.Ub(),a.Cc(17,v,15,10,"ion-row",14),a.Ub()),2&t){const t=a.vc(13);a.Eb(6),a.Fc(i.name),a.Eb(3),a.oc("ngIf",i.cart.length>0),a.Eb(2),a.oc("fullscreen",!0)("appParallax",t),a.Eb(1),a.zc("background-image","url("+i.picture+")"),a.Eb(3),a.oc("options",i.opts),a.Eb(1),a.oc("ngForOf",i.listOfCategory),a.Eb(1),a.oc("ngForOf",i.listOfFood)}},directives:[n.r,n.R,n.j,n.i,n.s,n.P,o.n,n.l,p,n.F,n.M,o.m,n.h,n.L,n.k,n.x,n.O],pipes:[o.b,o.d],styles:["ion-toolbar[_ngcontent-%COMP%]   ion-icon[_ngcontent-%COMP%]{font-size:25px}ion-content[_ngcontent-%COMP%]{position:absolute;--background:#f1f1f1;--padding-bottom:50px}.light-bg[_ngcontent-%COMP%]{background:#fff;z-index:10}.header-image[_ngcontent-%COMP%]{background-repeat:no-repeat;background-position:50%;background-size:cover;height:30vh;will-change:transform}ion-list-header[_ngcontent-%COMP%]{--background:#a0b67d}ion-list[_ngcontent-%COMP%]{--ion-background-color:#3d85a7}.meal-row[_ngcontent-%COMP%]{padding-bottom:0}.meal-image[_ngcontent-%COMP%]{width:100%;height:100%;background-position:50%;background-size:cover;background-repeat:no-repeat;border-radius:5px}.border-bottom[_ngcontent-%COMP%]{border-bottom:1px solid var(--ion-color-step-150,rgba(0,0,0,.07))}ion-slides[_ngcontent-%COMP%]{padding-right:0;margin-top:34px;margin-bottom:-34px;background:hsla(0,0%,72.5%,.9215686274509803);top:calc(env(safe-area-inset-top) - 34px)}.slides-visible[_ngcontent-%COMP%]{opacity:1;transition:1s}.slides-hidden[_ngcontent-%COMP%]{opacity:0;transition:1s}.active-category[_ngcontent-%COMP%]{--background:var(--ion-color-primary);--color:#fff;--border-radius:10px;font-weight:600}ion-badge[_ngcontent-%COMP%]{color:#fff;position:absolute;top:-9px;right:2px;border-radius:100%}.cart-icon[_ngcontent-%COMP%]{font-size:50px}.cart-length[_ngcontent-%COMP%]{color:var(--ion-color-primary);position:absolute;top:18px;left:25px;font-weight:600;font-size:1em;min-width:25px;z-index:10}.sticky-row[_ngcontent-%COMP%]{position:sticky;top:calc(env(safe-area-inset-top) - -55px);z-index:2;background:hsla(0,0%,72.5%,.9215686274509803);box-shadow:0 9px 11px -15px rgba(0,0,0,.75);display:flex;flex-direction:row;align-items:flex-end}"]}),t})()}];let x=(()=>{class t{}return t.\u0275fac=function(i){return new(i||t)},t.\u0275mod=a.Ob({type:t}),t.\u0275inj=a.Nb({imports:[[r.j.forChild(C)],r.j]}),t})();var F=e("bLo3");let k=(()=>{class t{}return t.\u0275fac=function(i){return new(i||t)},t.\u0275mod=a.Ob({type:t}),t.\u0275inj=a.Nb({imports:[[o.c,s.e,n.S,F.a,x]]}),t})()}}]);