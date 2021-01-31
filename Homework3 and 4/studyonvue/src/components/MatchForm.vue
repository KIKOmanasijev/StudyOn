<template>
    <div>
        <input type="hidden" name="UserId" value="c866c1e6-a199-43bf-98e8-f4a717643cb9">
        <input type="hidden" name="CourtId" value="364978134">       

        <div class="form-group">
            <label for="MaxPlayers">Max Player</label>
             <input type="number" class="form-control" id="MaxPlayers" v-model="maxPlayers" name="MaxPlayers">
        </div>

        <div class="form-group">
            <label for="type">Type of Sport</label>
            <select class="form-control" id="type" v-model="type" name="Type">
                <option value="Football">Футбал</option>   
                <option value="Footsal">Футсал</option>
                <option value="Basketball">Koшарка</option>
                <option value="Tennis">Тенис</option>
                <option value="Handball">Ракомет</option>
                <option value="Volleyball">Одбојка</option>
            </select>
        </div>

        <div class="form-group">
            <label for="start">Start Time</label>
            <input type="datetime-local" id="start" name="StartTime" v-model="startTime">
        </div>

        <div class="form-group">
            <label for="end">End Time</label>
            <input type="datetime-local" id="end" name="EndTime" v-model="endTime">
        </div>

        <button class="btn btn-primary" @click="createMatch">Save</button>
        <button class="btn btn-secondary">Cancel</button>
    </div>
</template>

<script>
export default {
    data(){
        return {
            userId: 'c866c1e6-a199-43bf-98e8-f4a717643cb9',
            courtId: '364978134',
            maxPlayers: 0,
            type: "Football",
            startTime: null,
            endTime: null
        }
    },
    inject: ['addMatch'],
    methods: {
        createMatch(){
            this.addMatch({
                userId: this.userId,
                courtId: this.courtId,
                maxPlayers: this.maxPlayers,
                type: this.type,
                startTime: this.startTime,
                endTime: this.endTime
            })
        }
    }
}
</script>

<style>

</style>