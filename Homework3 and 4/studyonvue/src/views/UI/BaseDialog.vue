<template>
    <div class="dialog-wrapper">
        <div class="bg" @click="toggleModal"></div>
        <dialog open>
            <slot name="title"></slot>

            <section>
                <slot name="content"></slot>
            </section>           

        </dialog>
    </div>
</template>

<script>
export default {
    inject: ['toggleModal']
}
</script>

<style scoped>
    .dialog-wrapper {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
    }

    .bg {
        background: rgba(0,0,0,.25);
        height: 100%;
        width: 100%;
    }

    dialog {
        position: fixed;
        top: 50%;
        transform: translateY(-50%);
    }
</style>