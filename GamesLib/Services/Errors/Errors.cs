using ErrorOr;

namespace GamesLib.Services.Errors;

public static class GameErrors{

    public static class Errors{

        public static Error NotFound => Error.NotFound(
            code: "Not found",
            description: "The game is not exist"
        );

        public static Error EmptyTitle => Error.Validation(
            code: "Empty title",
            description: "The length of title must be at last 1"
        );

        public static Error EmptyList => Error.Validation(
            code: "Empty list",
            description: "List must containes at least 1 item"
        );


    }

}