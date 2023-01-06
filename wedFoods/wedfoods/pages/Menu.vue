<template>
  <div>
<!--main page-->
    <div class="container px-4 px-lg-5 my-5">
        <div class="text-center text-black">
            <h1 class="display-4 fw-bolder">Thực đơn</h1>
            <p class="lead fw-normal text-black-50 mb-0">Hãy đặt hàng  ngay</p>
        </div>
    </div>
       <div class="container">
      <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto text-center">
        <h1 class="display-4">Món ăn ngon</h1>
      </div>
<div>
  <b-tabs content-class="mt-3 ListFood" fill >
    <b-tab title="Món ắn" >

     <div class="container bootdey">
      <div class="row">
        <div
          v-for="(listmenufood, index) in listmenufood"
          :key="index"
           class="product-grid col-xs-12 col-sm-6 col-md-4"
          >
          <Foodedit
            :food="listmenufood"

          />
        </div>
      </div>
     </div>
    </b-tab>
    <b-tab title="Thức uống">

     <div class="container bootdey">
      <div class="row">
        <div
          v-for="(listmenudrinks, index) in listmenudrinks"
          :key="index"
           class="product-grid col-xs-12 col-sm-6 col-md-4"
         >
          <Foodedit
            :food="listmenudrinks"

          />
        </div>
      </div>
     </div>
    </b-tab>
    <b-tab title="Tráng miệng">

     <div class="container bootdey">
      <div class="row">
        <div
          v-for="(listmenudessert, index) in listmenudessert"
          :key="index"
           class="product-grid col-xs-12 col-sm-6 col-md-4"
         >
          <Foodedit
            :food="listmenudessert"

          />
        </div>
      </div>
     </div>

    </b-tab>
    <b-tab title="Tất cả"  active>

     <div class="container bootdey">
      <div class="row">
        <div
          v-for="(food, index) in listFood"
          :key="index"
           class="product-grid col-xs-12 col-sm-6 col-md-4"
         >
          <Foodedit
            :food="food"
            @add-to-cart="addCart"
            @out-of-stock="alert"
          />
        </div>
      </div>
     </div>
      
     </b-tab>
  </b-tabs>
</div>

    </div>
    
    </div>
</template>
<script>
import Foodedit from '@/components/index/Foodedit'

import Apidata from '@/api/Apidata'

export default {
  components: { Foodedit },
   layout: 'default',
  data() {
    return {
      listFood: [],
     listmenu: [],
     listmenufood: [],
     listmenudrinks: [],
     listmenudessert: [],
    }
  },
  async created() {
    await this.getfood()
    await this.getmenu()
    await this.getmenufood()
    await this.getmenudrinks()
    await this.getmenudessert()

  },
  mounted() {
     const recaptchaScript = document.createElement('script')
      recaptchaScript.setAttribute('src', 'https://getbootstrap.com/docs/5.1/dist/js/bootstrap.bundle.min.js')
      document.head.appendChild(recaptchaScript)
  },
  methods: {
   
    async getfood() {
      try {
        const { data } = await Apidata.getfood(this.$axios)
        console.log(data)

        this.listFood = data
      } catch (err) {
        console.log(err)
      }
    },

     async getmenu() {
      try {
        const { data } = await Apidata.getmenu(this.$axios)
        console.log(data)
        this.listmenu = data

      } catch (err) {
        console.log(err)
      }
    },
   
   
     async getmenufood() {
      try {
        const { data } = await Apidata.getfoodbymenuyid(this.$axios, 1)
        console.log(data)
        this.listmenufood = data

      } catch (err) {
        console.log(err)
      }
    },

   
     async getmenudrinks() {
      try {
        const { data } = await Apidata.getfoodbymenuyid(this.$axios, 2)
        console.log(data)
        this.listmenudrinks = data

      } catch (err) {
        console.log(err)
      }
    },   

   
     async getmenudessert() {
      try {
        const { data } = await Apidata.getfoodbymenuyid(this.$axios, 3)
        console.log(data)
        this.listmenudessert = data

      } catch (err) {
        console.log(err)
      }
    },


  },
}
</script>
<style >
.ListFood{
  border: 1px solid rgb(228, 221, 221);
  padding: 40px;
  border-radius: 10px;
  min-width: 80%;
  background: rgb(223, 223, 230);
}
</style>