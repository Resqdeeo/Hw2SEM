const typesAndColors = {
    "bug": "#059669",
    "dragon": "#2EC4B6",
    "grass": "#16C172",
    "steel": "#73E2A7",
    "dark": "#434649",
    "flying": "#434649",
    "normal": "#C18CBA",
    "ghost": "#9A54A1",
    "rock": "#63320B",
    "ground": "#885629",
    "fighting": "#C75000",
    "fire": "#EF271B",
    "electric": "#FFBF00",
    "poison": "#6E44FF",
    "psychic": "#DB00B6",
    "fairy": "#EE4268",
    "water": "#4361EE",
    "ice": "#90E0EF"
}

const typeToColor = (type) => {
    let lowerType = type.toLowerCase();

    if(typesAndColors[lowerType] !== undefined)
        return typesAndColors[lowerType];

    return "#0080FF";
}

export default typeToColor;