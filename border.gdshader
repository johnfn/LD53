shader_type canvas_item;

uniform float border_width : hint_range(0, 10) = 4.0;
uniform vec4 border_color : source_color = vec4(1.0, 1.0, 1.0, 1.0);
uniform vec2 texture_size = vec2(100, 100);

void fragment() {
    vec2 uv = UV;
    float left_edge = border_width / texture_size.x;
    float right_edge = 1.0 - left_edge;
    float top_edge = border_width / texture_size.y;
    float bottom_edge = 1.0 - top_edge;

    vec4 tex_color = texture(TEXTURE, uv);

    if (uv.x < left_edge || uv.x > right_edge || uv.y < top_edge || uv.y > bottom_edge) {
        COLOR = border_color;
    } else {
        COLOR = tex_color;
    }
}