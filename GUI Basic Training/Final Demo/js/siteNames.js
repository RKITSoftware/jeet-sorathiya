export default class SiteNames {
    constructor() {
        // Private properties
        this._names = [
            "AtCoder",
            "CodeChef",
            "CodeForces",
            "HackerEarth",
            "HackerRank",
            "LeetCode",
        ];
        this._count = {};
        this._names.forEach((name) => {
            this._count[name] = 0;
        });
        //console.log(this._count);
    }

    // Getter for site name
    get names() {
        console.log("getter method for names called");
        return this._names;
    }

    // Get count of site name
    getCount(name) {
        console.log("getCount called");
        return this._count[name];
    }

    // increment the count
    incrementCount(name) {
        console.log("incrementCount called");
        if (this._names.includes(name)) {
            this._count[name]++;
        }
    }

}
