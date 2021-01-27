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
                                      Како може да креираме профил?
                                  </div>
                              </div>
                          </div>

                          <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordion" style="">
                              <div class="card-body">
                                  Во долниот лев агол може да видите кругче каде што откако ке кликнете на иконката ќе ви се појават две опции: Логирање и Регистрација. 
                                  Најпрво мора да се регистрирате, за подоцна да можете со тоа корисничко име и лозинка да се логирате кога и да посакате.
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingTwo">
                              <div class="mb-0">
                                  <div class="btn btn-link" role="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="true" aria-controls="collapseTwo">
                                      Што можам, а што не да правам на страната без да морам да се регистрирам?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseTwo" class="collapse show" aria-labelledby="headingTwo" data-parent="#accordion" style="">
                              <div class="card-body">
                                    Не-регистиран корисник може да ги гледа сите игралишта(листа и маркирани на мапата). 
                                    Но не може да додава натпревари, да остава рејтинг и да се пријавува на натпревар.
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingThree">
                              <div class="mb-0">
                                  <div class="btn btn-link" role="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                     Каква се намена имаат игралишта листани во оваа апликација?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordion">
                              <div class="card-body">
                                  Има за Фудбал, Футсал, Кошарка, Тенис, Ракомет и Одбојка.
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingFour">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                                     Каде можам да ги видам деталите за игралиштата?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordion">
                              <div class="card-body">
                                  Кога се отвори листата на сите игралишта има по неколку податоци за секое игралиште, доколку сакаш да видиш повеќе податоци(детали) за некое игралиште
                                  можеш со клик на него и ќе се отворат деталите за тоа игралиште.
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingFive">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                                     За што точно е наменета страната?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseFive" class="collapse" aria-labelledby="headingFive" data-parent="#accordion">
                              <div class="card-body">
                                  Па страната може да послужи на пример за некој студент што е нов во главниот град, сака да спортува но не ги знае игралиштата, ја отвара апликацијата и ги 
                                  разгледува најблиските игралиштата. Исто доколку некој сака да игра, но нема тим/му фали играч оваа апликација може да помогне доколку некој друг има објавено
                                  натпревар.
                              </div>
                          </div>
                      </div>

                      <div class="card">
                          <div class="card-header" id="headingSix">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                                      Дали може некако да ги листам натпреварите според категорија?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseSix" class="collapse" aria-labelledby="headingSix" data-parent="#accordion">
                              <div class="card-body">
                                  Секако дека да, доколку ја отвориш почетната страна, каде што се листани сите натпревари, имаш опција да избереш според што сакаш да ти се излистаат
                                  натпреварите, можеш да избереш сите, Фудбал, Футсал, Кошарка ...
                              </div>
                          </div>
                    </div>

                    <div class="card">
                          <div class="card-header" id="headingSeven">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseSeven" aria-expanded="false" aria-controls="collapseSix">
                                      Дали доколку не се регистрирам можам да додадам натпревар?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseSeven" class="collapse" aria-labelledby="headingSeven" data-parent="#accordion">
                              <div class="card-body">
                                  Не, мора корисникот да биде најавен за да може да додава натпревари, како не-регистриран корисник може само да се гледаат натпревари и игралишта.
                              </div>
                          </div>
                    </div>

                      <div class="card">
                          <div class="card-header" id="headingEight">
                              <div class="mb-0">
                                  <div class="btn btn-link collapsed" role="button" data-toggle="collapse" data-target="#collapseEight" aria-expanded="false" aria-controls="collapseSix">
                                      Каде можам да видам уште колку играчи недостасуваат?
                                  </div>
                              </div>
                          </div>
                          <div id="collapseEight" class="collapse" aria-labelledby="headingEight" data-parent="#accordion">
                              <div class="card-body">
                                  При самото листање на натпреварите, до секоја сликичка пишува уште колку играчи недостасуваат. Но истото може да се види и при
                                  клик на натпреварот за којшто сакаш да видиш уште колку играчи недостасуваат.
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
    font-size: 20px;
    font-weight: 600;
    color: #685EFF;
  }
</style>