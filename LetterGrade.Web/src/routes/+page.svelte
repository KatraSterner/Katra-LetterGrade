<!-- 
    reference core
    page with form
        - input for number percentage grade
        - Button "get grade" submit button
    when button is pressed:
        - send data to ApiService
        - wait for response
        - display the returned letter grade
-->
<script lang="ts">
    let enteredPercentage = $state(0);
    let result = $state<{ gradePercentage: number; letter: string } | null>(null);    
    async function getGrade(e: Event) {
        e.preventDefault();
        
        const response = await fetch("http://localhost:5034/api/grades/calculate", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(Number(enteredPercentage))
        });
        
        result = await response.json();
    }
</script>

<main class="text-slate-300 flex flex-col" >
    <div class="bg-slate-600 p-3">
        <h1 class="text-3xl font-bold">Calculate Your Grade</h1>
    </div>

    <form onsubmit={getGrade} class="flex flex-col items-center">
        <input
                type="number"
                placeholder="Enter your score..."
                bind:value={enteredPercentage}
                required
                class="bg-slate-400 rounded-md px-6 text-lg text-white m-1 mt-5"
                max="100"
                min="0"
        />
        <button type="submit" class="bg-slate-600 rounded-md px-5 text-lg text-slate-300 m-1 hover:bg-slate-500">Get Grade</button>
    </form>

    {#if result} 
        <div class="flex flex-col items-center p-3">
            <div class="bg-slate-500 rounded-md px-2 text-lg text-white m-1 mt-5">
                <p class="p-3">
                    Grade Entered: {result?.gradePercentage}%
                </p>
            </div> 
            <div class="bg-slate-500 rounded-md px-2 text-lg text-white m-1">
                <p class="p-3">
                    Your letter Grade: {result?.letter}
                </p>
            </div>
        </div>
    {/if}
    
    
    
</main>
