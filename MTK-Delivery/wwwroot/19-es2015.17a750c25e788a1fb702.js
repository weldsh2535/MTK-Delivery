(window.webpackJsonp=window.webpackJsonp||[]).push([[19,18],{"+cje":function(t,r,e){"use strict";e.d(r,"a",function(){return h});var n=e("HDdC"),s=e("XEKg"),a=e("5Jak"),i=e("/GcI"),u=e("cxbk"),o=e("fXoL"),c=e("tk/3");let h=(()=>{class t{constructor(t){this.http=t,this.APIURL=u.a.apiURL}create(t){return this.http.post(this.APIURL+"/Restaurant",t)}getAllRestaurant(){return this.http.get(this.APIURL+"/Restaurant")}updateRestaurant(t){return this.http.put(this.APIURL+"/Restaurant/",t)}removeRestaurant(t){return this.http.delete(this.APIURL+"/Restaurant/"+t).toPromise()}handleError(t){return n.a.throw(400===t.status?new s.a(t.json()):404===t.status?new a.a:new i.a(t))}}return t.\u0275fac=function(r){return new(r||t)(o.cc(c.a))},t.\u0275prov=o.Mb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()},ldse:function(t,r,e){"use strict";e.d(r,"a",function(){return a});var n=e("2Vo4"),s=e("fXoL");let a=(()=>{class t{constructor(){this.currentAddress=new n.a({}),this.restaurant=new n.a({}),this.status=new n.a({}),this.location=new n.a({}),this.orderId=new n.a({}),this.RestaurantLocation=new n.a({}),this.resId=new n.a({}),this.listOfCatagoryFilter=new n.a({}),this.deriverId=new n.a({}),this.customerId=new n.a({}),this.driverName=new n.a({})}getCurrentAddress(){return this.currentAddress}getMenuFilter(){return this.listOfCatagoryFilter}getLocation(){return this.location}getStatus(){return this.status}getRestaurantLocation(){return this.RestaurantLocation}getRestaurantId(){return this.resId}getDriverId(){return this.deriverId}getCustomerId(){return this.customerId}getDriverName(){return this.driverName}}return t.\u0275fac=function(r){return new(r||t)},t.\u0275prov=s.Mb({token:t,factory:t.\u0275fac,providedIn:"root"}),t})()}}]);