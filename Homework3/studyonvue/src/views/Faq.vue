<template>
  <div class="faq">
    <Sidemenu/>
        <div class="faq-wrapper">
            <h2>Често поставувани прашања</h2>

            <div class="row mt-5">
              <div class="offset-lg-2 col-lg-8">
                  <!-- .row -->
                  <div id="accordion" class="accordion-dark">
                      <div class="card">
                          <div class="card-header" id="headingOne">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                                      Lorem ipsum dolor sit amet consectetur adipisicing elit?
                                  </div>
                              </div>
                          </div>

                          <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion" style="">
                              <div class="card-body">
                                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?

                              </div>
                          </div>
                      </div>
                      <div class="card">
                          <div class="card-header" id="headingTwo">
                              <div class="mb-0">
                                  <div class="btn btn-link" role="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                                      Lorem ipsum dolor sit amet, consectetur adipisicing elit?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseTwo" class="collapse show" aria-labelledby="headingTwo" data-parent="#accordion" style="">
                              <div class="card-body">
                                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>
                      <div class="card">
                          <div class="card-header" id="headingThree">
                              <div class="mb-0">
                                  <div class="btn btn-link" role="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                     Lorem ipsum dolor sit amet consectetur, adipisicing elit?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                              <div class="card-body">
                                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingThree">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                     Lorem ipsum dolor sit amet consectetur adipisicing elit?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                              <div class="card-body">
                                 Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingFour">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                     Lorem ipsum, dolor sit amet consectetur adipisicing elit?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordion">
                              <div class="card-body">
                                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingFive">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                                     Lorem ipsum dolor sit amet consectetur adipisicing elit?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseFive" class="collapse" aria-labelledby="headingFive" data-parent="#accordion">
                              <div class="card-body">
                                  Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingSix">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                                      Lorem ipsum, dolor sit amet consectetur adipisicing elit?

                                  </div>
                              </div>
                          </div>
                          <div id="collapseSix" class="collapse" aria-labelledby="headingSix" data-parent="#accordion">
                              <div class="card-body">
                                 Lorem, ipsum dolor sit amet consectetur adipisicing elit. Dolore nihil perspiciatis eius! Cum atque aspernatur fugiat provident ducimus velit reiciendis vel veniam mollitia aut? Repudiandae, nemo dignissimos. Assumenda, aliquid dolores?
                              </div>
                          </div>
                      </div>
                  </div>
                  <!-- .row end -->
              </div>
            </div>
              
      </div>
  </div>
</template>

<script>
import Sidemenu from "../components/Sidemenu";

export default {
  name: 'Faq',
  components: {
    Sidemenu
  },
}
</script>

<style scoped>
 .faq {
   display: flex;
   width: 100%;
 }
  .faq-wrapper {
    width: 100%;
    padding: 50px 0;
  }

  .faq-wrapper h2 {
    margin-top: 10px;
    text-align: center;
  }

  .accordion-dark .card {
    margin-bottom: 25px;
    border: 0px;
    box-shadow: 0px 0px 10px 0px rgba(0, 0, 0, 0.06);
    }

  .accordion-dark .card-header {
    background: #e7e4ee;
    border: 0px;
  }  

  #accordion .btn-link {
    text-align: left;
  }

  .btn-link {
    font-size: 18px;
    font-weight: 600;
    color: #685EFF;
  }
</style>