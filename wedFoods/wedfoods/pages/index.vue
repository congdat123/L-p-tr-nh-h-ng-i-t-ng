<template>
  <main>
    <Slidelist />
    <section>
        <div class="container">
            <div class="text-center mb-4">
                <h2 class="display-20 display-md-18 display-lg-16">Thực đơn</h2>
            </div>
              <div class="row" style="">
                      <div  v-for="(listmenu, index) in listmenu"
                      :key="index"
                      class="col-sm-6 col-lg-4 mb-1-9 mb-lg-0">
                        <CategoryMenu 
                        :listmenu="listmenu"/>
                </div>
              </div>
        </div>
    </section>
    <div class="container bootdey">
            <div class="">
              <h2>NỔI BẬT</h2>
            </div>
        <div class="row">
         <div  v-for="(listFoodnew,index) in listFoodnew" :key="index"
            class="product-grid col-xs-12 col-sm-6 col-md-4">    
            <OutstandingFood 
            :listFoodnew="listFoodnew"/>
          </div>
         </div>
    </div>
    <div class="tile">
      <h3 class="">TIN TỨC</h3>
    </div>
    <div 
      v-for="(News, index) in listnews"
          :key="index"
      >
        <Newlist
        :News="News"
         />
    </div>     
  </main>
</template>
<script>
import Newlist from '@/components/index/Newlist'
import Slidelist from '@/components/index/Slidelist'
import OutstandingFood from '@/components/index/OutstandingFood'
import CategoryMenu from '@/components/index/CategoryMenu'
import Apidata from '@/api/Apidata'
export default {
  components: { 
    Newlist,
    Slidelist,
    OutstandingFood,
    CategoryMenu,
  } , 
   layout: 'default',
  data() {
    return {
      listFoodnew: [],
      listnews: [],
     listmenu: [],
     listSlider: [],
    }
  },
  async created() {
    await this.getnews()
    await this.getfoodnew()
    await this.getmenu()
    await this.getSlider()
  },
  mounted() {
     const recaptchaScript = document.createElement('script')
      recaptchaScript.setAttribute('src', 'https://getbootstrap.com/docs/5.1/dist/js/bootstrap.bundle.min.js')
      document.head.appendChild(recaptchaScript)
  },
  methods: {
  async getnews() {
      try {
        const { data } = await Apidata.getnews(this.$axios)
        console.log(data)
       this.listnews = data
       
      } catch (err) {
        console.log(err)
      }
    },

 async getfoodnew() {
      try {
        const { data } = await Apidata.GetOutstandingFood(this.$axios, 1)
        console.log(data)

        this.listFoodnew = data
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

 async getSlider() {
      try {
        const { data } = await Apidata.getSlider(this.$axios)
        console.log(data)
        this.listSlider = data

      } catch (err) {
        console.log(err)
      }
    },

  },
}
</script>
<style scoped>
.tile{
  height: 50px;
  text-align: center;
  font-family: sans-serif;
  border: 1 solid #fff;
  background: #fff;
  margin-bottom: 0px;

}
.bootdey{
  border: 1px solid #fff;
  border-radius: 10px;
  min-width: 80%;
  background: #FFF;
  text-align: center;
}
.h-100 {
    height: 100%!important;
}

.box-hover {
    min-height: 210px;
    position: relative;
}

.cover-background {
    position: relative !important;
    background-size: cover !important;
    overflow: hidden !important;
    background-position: center !important;
    background-repeat: no-repeat !important;
}

.margin-30px-bottom {
    margin-bottom: 30px;
}

.box-hover:before {
    position: absolute;
    content: "";
    top: 0;
    left: 0;
    background: rgba(0,0,0,0.76);
    background: -webkit-linear-gradient(top, transparent, #000 116%);
    background: linear-gradient(-180deg, transparent, #000 116%);
    z-index: 0;
    width: 100%;
    height: 100%;
}

</style>
