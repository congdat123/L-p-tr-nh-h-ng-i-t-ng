<template>
            <div class="containerf">
            <div class="login-form">
                <form @submit.prevent="loginUser">
                    <h1>Sign In</h1>
                    <div class="input-box">
                        <i ></i>
                        <input type="text" v-model="dataSubmit.username" placeholder="Nhập username" >
                    </div>

                    <div class="input-box">
                        <i ></i>
                        <input type="password"   v-model="dataSubmit.password" placeholder="Nhập mật khẩu">
                    </div>                  
                    <div class="btn-box">
                 
                        <button type="submit">
                            Đăng nhập
                        </button>
                        <div class="text">
                             <p>chưa có tài khản đăng ký:  <strong>  <a href="/register">tại đây</a></strong></p>
                        </div>                                              
                    </div>
                </form>
            </div>
            </div>

</template>
<script>
import { mapActions } from 'vuex'
import accountApi from '@/api/accountApi'
export default {
    middleware: [
    'isLogin',
  ],
  layout: 'default',
 data(){
        return{
            dataSubmit:  {
                customername: '',                 
                customerpassword: '',
            }
        }
    },
    methods:{
        ...mapActions({
      setToken: 'user/setToken',
      setRole: 'user/setRole',
    }),
    async loginUser() {
        
        try {
          if(this.x > 2){
              alert("acc lock!!")
              this.$router.push('/lock_page')
          }else{
              const data = await accountApi.login(this.$axios, this.dataSubmit)
              console.log(data.access_token)
              await this.setToken(data.access_token)
              await this.setRole(data.role)
              this.x = 0;
              this.$router.push('/')
          }
        } catch (err) {
          this.x = this.x+1;
          alert('Sai tên đăng nhập hoặc mật khẩu')
      
        }
      },
    }
}
</script>
<style scoped>
main{
    background-color: #dddddd;
    min-height: 300px;
    padding: 7.5px 15px;
}
p{
    text-align: center;
}
.text{
    margin-top: 15px;
    padding: 10px;
}
.containerf{
    
    margin-top: 100px;
    margin-bottom: 100px;
}
.login-form{
    width: 100%;
    max-width: 400px;
    margin: 20px auto;
    background-color: #e1e8eb;
    padding: 15px;
    border: 2px dotted #cccccc;
    border-radius: 10px;
    height: 450px;
}
h1{
    color: #009999;
    font-size: 20px;
    margin-bottom: 30px;
    text-align: center;
    font-family: sans-serif;
    font-size: 40px;
}
.input-box{
    margin-bottom: 30px;
}
.input-box input{
    padding: 7.5px 15px;
    width: 100%;
    border: 1px solid #cccccc;
    outline: none;
    border-radius: 2px;
}
.btn-box{
    text-align: right;
    margin-top: 30px;
}
.btn-box button{
    padding: 7.5px 15px;
    border-radius: 5px;
    background-color: #009999;
    color: #ffffff;
    border: none;
    outline: none;
    
}
button:hover {
  background: rgb(36, 123, 223);
}
</style>